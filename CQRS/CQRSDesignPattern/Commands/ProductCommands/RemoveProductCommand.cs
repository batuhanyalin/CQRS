using CQRS.DAL.Entities;

namespace CQRS.CQRSDesignPattern.Commands.ProductCommands
{
    public class RemoveProductCommand
    {
        public int ProductId { get; set; }

        public RemoveProductCommand(int productId) //Burada yapıcı metoda dahil ediyoruz
        {
            ProductId = productId;
        }
    }
}
