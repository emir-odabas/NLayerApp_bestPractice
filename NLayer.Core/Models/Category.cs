namespace NLayer.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }  //Navigation property   Birden fazla product ı olabilir.


    }
}
