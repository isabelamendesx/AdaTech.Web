using System.ComponentModel.DataAnnotations;

namespace DeliveryGuyAPI.Models
{
    public class DeliveryGuy
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public VehicleType Vehicle {  get; set; }
        public Rating rating { get; set; } = Rating.Excellent;
        public Status status { get; set; } = Status.Available;
        public required string CPF {  get; set; } 
    }
}
