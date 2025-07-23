namespace SkyMirror_backend.BusinessLogic.Dto.CartProduct
{
    public class AddCartProductRequestDto
    {
        public int CartId { get; set; }

        public int ProductId { get; set; }

        public int ProductQuantity { get; set; }
    }
}
