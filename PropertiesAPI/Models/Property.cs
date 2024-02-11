namespace PropertiesAPI.Models
{
    public class Property
    {
        public int Id { get; set; }
        public PropertyType Type { get; set; }
        
        public decimal AreaSize { get; set; }

        public decimal Price { get; set; }

    }
}
