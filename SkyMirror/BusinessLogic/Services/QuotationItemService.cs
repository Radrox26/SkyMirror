using SkyMirror.BusinessLogic.Dto.QuotationItem;
using SkyMirror.BusinessLogic.Interfaces;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.Entities;

public class QuotationItemService : IQuotationItemService
{
    private readonly IQuotationItemRepository _quotationItemRepository;
    private readonly IProductRepository _productRepository;

    public QuotationItemService(IQuotationItemRepository quotationItemRepository, IProductRepository productRepository)
    {
        _quotationItemRepository = quotationItemRepository;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<QuotationItemResponseDto>> GetItemsByQuotationIdAsync(int quotationId)
    {
        var items = await _quotationItemRepository.GetByQuotationIdAsync(quotationId);

        List<QuotationItemResponseDto> response = new List<QuotationItemResponseDto>();
        foreach (var item in items)
        {
            var productName = await _productRepository.GetProductNameAsync(item.ProductId);
            response.Add(new QuotationItemResponseDto(item.QuotationItemId, item.QuotationId, item.ProductId, productName, item.Quantity, item.Price));
        }

        return response;
    }

    public async Task<QuotationItemResponseDto> GetByIdAsync(int id)
    {
        var item = await _quotationItemRepository.GetByIdAsync(id)
                   ?? throw new KeyNotFoundException("Quotation item not found");

        var productName = await _productRepository.GetProductNameAsync(item.ProductId);
        return new QuotationItemResponseDto(item.QuotationItemId, item.QuotationId, item.ProductId, productName, item.Quantity, item.Price);
    }

    public async Task<int> CreateAsync(CreateQuotationItemRequestDto request)
    {
        var item = new QuotationItem
        {
            QuotationId = request.QuotationId,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            Price = request.Price
        };

        return await _quotationItemRepository.AddAsync(item);
    }

    public async Task UpdateAsync(int id, UpdateQuotationItemRequestDto request)
    {
        var item = await _quotationItemRepository.GetByIdAsync(id)
                   ?? throw new KeyNotFoundException("Quotation item not found");

        item.ProductId = request.ProductId;
        item.Quantity = request.Quantity;
        item.Price = request.Price;

        await _quotationItemRepository.UpdateAsync(item);
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _quotationItemRepository.GetByIdAsync(id)
                   ?? throw new KeyNotFoundException("Quotation item not found");

        await _quotationItemRepository.DeleteAsync(id);
    }
}
