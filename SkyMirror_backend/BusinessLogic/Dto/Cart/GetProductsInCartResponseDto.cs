namespace SkyMirror_backend.BusinessLogic.Dto.Cart
{
    public class GetProductInCartResponseDto
    {
        public string PanelName { get; }
        public int Quantity { get; }
        public decimal PanelPrice { get; }

        public GetProductInCartResponseDto(string panelName, int quantity, decimal panelPrice)
        {
            PanelName = panelName;
            Quantity = quantity;
            PanelPrice = panelPrice;
        }
    }
}
