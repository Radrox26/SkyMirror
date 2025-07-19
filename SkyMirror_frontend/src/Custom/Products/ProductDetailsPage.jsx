import Sidebar from "../SharedUI/sidebar";
import TopBar from "../SharedUI/topbar";
import './ProductDetailsPage.css';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axiosInstance from '../../Axios/axiosInstance';

function ProductDetailsPage() {
    const { productId } = useParams();
    const [product, setProduct] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState('');
    const [images, setImages] = useState([]);
    const [selectedImage, setSelectedImage] = useState(null);

    const allImages = import.meta.glob('../../Images/ProductImages/**/*.png', { eager: true });

    useEffect(() => {
        const fetchProductDetails = async () => {
            try {
                const response = await axiosInstance.get(`/product/${productId}`, {
                    headers: {
                        Authorization: `Bearer ${localStorage.getItem('accessToken')}`
                    }
                });
                setProduct(response.data);
                setLoading(false);
            } catch (err) {
                setError('Failed to load product details. ' + (err.response?.data?.message || err.message));
                setLoading(false);
            }
        };

        fetchProductDetails();
    }, [productId]);

    useEffect(() => {
        if (product) {
            const panelType = getPanelType(product.panelName);
            const wattage = `${product.powerInWatts}W`;
            const folderPath = `/Images/ProductImages/${panelType}/${wattage}`;

            const matchedImages = Object.entries(allImages)
                .filter(([path]) => path.includes(folderPath))
                .map(([_, module]) => module.default);

            setImages(matchedImages);
            setSelectedImage(matchedImages[0] || null); // show first image initially
        }
    }, [product]);

    const getPanelType = (panelName) => {
        const name = panelName.toLowerCase();
        if (name.includes("topcon")) return "Topcon";
        if (name.includes("bifacial")) return "Bifacial";
        return "Monofacial";
    };

    if (loading) return <div className="loading">Loading product...</div>;
    if (error) return <div className="error">{error}</div>;

    return (
        <div className='product-details-page-wrapper'>
            <TopBar>
                <h1 className="product-details-topbar-title">Panel Name : {product.panelName}</h1>
            </TopBar>
            <Sidebar />
            <div className="product-details-content-wrapper">
                <div className="product-details-background-wrapper">
                </div>

                <div className="actual-details-container">
                    <div className="images-container">
                        {/* Selected Image */}
                        {selectedImage && (
                            <div className="selected-image-wrapper">
                                <img src={selectedImage} alt="Selected" className="selected-image" />
                            </div>
                        )}

                        {/* Thumbnail Images */}
                        <div className="images-wrapper-horizontal">
                            {images.map((imgSrc, index) => (
                                <img
                                    key={index}
                                    src={imgSrc}
                                    alt={`panel-${index}`}
                                    className={`thumbnail-image ${selectedImage === imgSrc ? 'active' : ''}`}
                                    onClick={() => setSelectedImage(imgSrc)}
                                />
                            ))}
                        </div>

                    </div>

                    {/* Other Details*/}
                    <div className="other-details-wrapper">

                        <div className="description-section">
                            <ul className="description-list">
                                {product.description
                                    .split('.') 
                                    .filter(line => line.trim() !== '') 
                                    .map((line, index) => (
                                        <li key={index}>{line.trim()}</li>
                                    ))}
                            </ul>
                        </div>

                        <div className="product-specifications">
                            <h3>Product Details</h3>
                            <table className="product-details-table">
                                <tbody>
                                    <tr>
                                        <td>Panel Name:</td>
                                        <td>{product.panelName}</td>
                                    </tr>
                                    <tr>
                                        <td>Price:</td>
                                        <td>Rs. {product.price}</td>
                                    </tr>
                                    <tr>
                                        <td>Power in Watts:</td>
                                        <td>{product.powerInWatts}</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <button
                                                className="buy-now-button"
                                                onClick={() => navigate(``)}>
                                                Buy Now
                                            </button>
                                        </td>
                                        <td>
                                            <button
                                                className="add-to-cart-button"
                                                onClick={() => navigate(``)}>
                                                Add to Cart
                                            </button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default ProductDetailsPage;
