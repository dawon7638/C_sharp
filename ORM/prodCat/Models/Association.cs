namespace prodCat.Models
{
    public class Association
    {
        public int AssociationId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}