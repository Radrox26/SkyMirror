import axios from 'axios';

// Create an Axios instance
const axiosInstance = axios.create({
    baseURL: 'https://localhost:7290/api', // backend API base URL
    headers: {
        'Content-Type': 'application/json'
    },
    withCredentials: true // allows sending cookies (like refreshToken)
});

// Request Interceptor - Attach Access Token
axiosInstance.interceptors.request.use(
    (config) => {
        const accessToken = localStorage.getItem('accessToken');
        if (accessToken) {
            config.headers['Authorization'] = `Bearer ${accessToken}`;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

// Response Interceptor - Handle 401 and refresh token
axiosInstance.interceptors.response.use(
    (response) => response,
    async (error) => {
        const originalRequest = error.config;

        if (
            error.response &&
            error.response.status === 401 &&
            !originalRequest._retry
        ) {
            originalRequest._retry = true;

            try {
                // Refresh token is automatically sent via HTTP-only cookie
                const refreshResponse = await axios.post(
                    'https://localhost:7290/api/auth/refresh-token',
                    {}, // no body needed
                    { withCredentials: true }
                );

                const { accessToken } = refreshResponse.data;
                localStorage.setItem('accessToken', accessToken);

                // Retry the original request with the new access token
                originalRequest.headers['Authorization'] = `Bearer ${accessToken}`;
                return axiosInstance(originalRequest);
            } catch (refreshError) {
                console.error('Refresh token expired or invalid. Redirecting to login.');
                localStorage.removeItem('accessToken');
                window.location.href = '/login';
                return Promise.reject(refreshError);
            }
        }

        return Promise.reject(error);
    }
);

export default axiosInstance;
