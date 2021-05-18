namespace ShoesAPI.DTOs
{
    public class ProductDto
    {
        public int product_id{get; set;}
        public int product_type_id {get; set;}
        public string name {get; set;}
        public int amount {get; set;}
        public long price {get; set;}
        public string description {get; set;}
        public string img {get; set;}
        public string size {get; set;}
        public int status {get; set;}
        public ProductDto(){
            amount = 0;
            status = 1;
        }
    }
}