using SkyMirror.BusinessLogic.Dto.Lead;
using SkyMirror.BusinessLogic.Interfaces;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.Entities;

namespace SkyMirror.BusinessLogic.Services
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IUserRepository _userRepository;

        public LeadService(ILeadRepository leadRepository, IUserRepository userRepository)
        {
            _leadRepository = leadRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<LeadResponseDto>> GetAllLeadsAsync()
        {
            var leads = await _leadRepository.GetAllAsync();
            return leads.Select(l => new LeadResponseDto(
                l.LeadId,
                l.UserId,
                l.InquiryDetails,
                l.Status,
                l.CreatedAt
            ));
        }

        public async Task<LeadResponseDto> GetLeadByIdAsync(int leadId)
        {
            var lead = await _leadRepository.GetByIdAsync(leadId);
            if (lead == null)
                throw new KeyNotFoundException("Lead not found");

            return new LeadResponseDto(lead.LeadId, lead.UserId, lead.InquiryDetails, lead.Status, lead.CreatedAt);
        }

        public async Task CreateLeadAsync(CreateLeadRequestDto request)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                throw new InvalidOperationException("User does not exist");

            var lead = new Lead
            {
                UserId = request.UserId,
                InquiryDetails = request.InquiryDetails,
                Status = "New"
            };

            await _leadRepository.AddAsync(lead);
        }

        public async Task UpdateLeadStatusAsync(int leadId, UpdateLeadRequestDto request)
        {
            var lead = await _leadRepository.GetByIdAsync(leadId);

            if (lead == null)
                throw new KeyNotFoundException("Lead not found");

            lead.InquiryDetails = request.InquiryDetails;
            lead.Status = request.Status;
            
            await _leadRepository.UpdateAsync(lead);
        }

        public async Task DeleteLeadAsync(int leadId)
        {
            var lead = await _leadRepository.GetByIdAsync(leadId);
            if (lead == null)
                throw new KeyNotFoundException("Lead not found");

            await _leadRepository.DeleteAsync(leadId);
        }

    }
}
