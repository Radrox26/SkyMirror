using SkyMirror.BusinessLogic.Dto.Lead;

namespace SkyMirror.BusinessLogic.Interfaces
{
    public interface ILeadService
    {
        Task<IEnumerable<LeadResponseDto>> GetAllLeadsAsync();
        Task<LeadResponseDto> GetLeadByIdAsync(int leadId);
        Task<int> CreateLeadAsync(CreateLeadRequestDto request);
        Task UpdateLeadStatusAsync(int leadId, UpdateLeadRequestDto request);
        Task DeleteLeadAsync(int leadId);

    }
}
