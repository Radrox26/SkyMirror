using SkyMirror.BusinessLogic.Dto.Quotation;
using SkyMirror.BusinessLogic.Dto.QuotationItem;
using SkyMirror.BusinessLogic.Interfaces;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.DataAccess.Repository;
using SkyMirror.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyMirror.BusinessLogic.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly IQuotationRepository _quotationRepository;
        private readonly IQuotationItemRepository _quotationItemRepository;
        private readonly ILeadRepository _leadRepository;

        public QuotationService(IQuotationRepository quotationRepository, IQuotationItemRepository quotationItemRepository, ILeadRepository leadRepository)
        {
            _quotationRepository = quotationRepository;
            _leadRepository = leadRepository;
            _quotationItemRepository = quotationItemRepository;
        }

        public async Task<IEnumerable<QuotationResponseDto>> GetAllQuotationsAsync()
        {
            var quotations = await _quotationRepository.GetAllAsync();
            return quotations.Select(q => new QuotationResponseDto(
                q.QuotationId,
                q.LeadId,
                q.SalesManagerId,
                q.TotalAmount,
                q.Status,
                q.CreatedAt
            ));
        }

        public async Task<QuotationResponseDto> GetQuotationByIdAsync(int id)
        {
            var q = await _quotationRepository.GetByIdAsync(id);
            if (q == null)
                throw new KeyNotFoundException("Quotation not found");

            return new QuotationResponseDto(
                q.QuotationId,
                q.LeadId,
                q.SalesManagerId,
                q.TotalAmount,
                q.Status,
                q.CreatedAt
            );
        }

        public async Task<IEnumerable<QuotationResponseDto>> GetQuotationsByLeadIdAsync(int leadId)
        {
            var quotations = await _quotationRepository.GetByLeadIdAsync(leadId);
            return quotations.Select(q => new QuotationResponseDto(
                q.QuotationId,
                q.LeadId,
                q.SalesManagerId,
                q.TotalAmount,
                q.Status,
                q.CreatedAt
            ));
        }

        public async Task<int> CreateQuotationAsync(CreateQuotationRequestDto request)
        {
            var lead = await _leadRepository.GetByIdAsync(request.LeadId);
            if (lead == null)
                throw new InvalidOperationException("Lead does not exist");

            var quotation = new Quotation
            {
                LeadId = request.LeadId,
                SalesManagerId = request.SalesManagerId,
                TotalAmount = request.TotalAmount,
                Status = request.Status,
            };

            int quotationId = await _quotationRepository.AddAsync(quotation);

            foreach (var item in request.QuotationItems)
            {
                var quotationItem = new QuotationItem
                {
                    QuotationId = quotationId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                };
                await _quotationItemRepository.AddAsync(quotationItem);
            }

            return quotationId;
        }

        public async Task UpdateQuotationAsync(int id, UpdateQuotationRequestDto request)
        {
            var existingQuotation = await _quotationRepository.GetByIdAsync(id);
            if (existingQuotation == null)
                throw new KeyNotFoundException("Quotation not found");

            existingQuotation.SalesManagerId = request.SalesManagerId;
            existingQuotation.TotalAmount = request.TotalAmount;
            existingQuotation.Status = request.Status;

            foreach (var updatedItem in request.QuotationItems)
            {
                var existingItem = existingQuotation.QuotationItems
                    .FirstOrDefault(qi => qi.QuotationItemId == updatedItem.QuotationItemId);

                if (existingItem != null)
                {
                    existingItem.ProductId = updatedItem.ProductId;
                    existingItem.Quantity = updatedItem.Quantity;
                    existingItem.Price = updatedItem.Price;
                }
            }

            await _quotationRepository.UpdateAsync(existingQuotation);
        }

        public async Task DeleteQuotationAsync(int id)
        {
            await _quotationRepository.DeleteAsync(id);
        }
    }
}
