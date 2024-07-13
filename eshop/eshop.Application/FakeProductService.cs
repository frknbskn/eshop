using eshop.Entities;

namespace eshop.Application
{
    public class FakeProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>()
            {
                new() {Id=1,Name="Ürün A",Description="Ürün A Açıklaması",Price=10,Rating=4.6},
                new() {Id=2,Name="Ürün B",Description="Ürün B Açıklaması",Price=10,Rating=4.6},
                new() {Id=3,Name="Ürün C",Description="Ürün C Açıklaması",Price=10,Rating=4.6},
                new() {Id=4,Name="Ürün D",Description="Ürün D Açıklaması",Price=10,Rating=4.6},
                new() {Id=5,Name="Ürün E",Description="Ürün E Açıklaması",Price=10,Rating=4.6},
            };
            return products;
        }
    }
        
}
