using DeliveryGuyAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace DeliveryGuyAPI.Data.Dtos
{
    public class CreateDeliveryGuyDto
    {
        [Required(ErrorMessage = "Delivery guy's name is required.")]
        [StringLength(50, ErrorMessage = "Delivery guy's name cannot exceed 50 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Delivery guy's vehicle type is required.")]
        [Range(0,2, ErrorMessage = "Delivery guy's vehicle type must be between 0 and 2.")]
        public VehicleType Vehicle { get; set; }

        [Range(1, 5, ErrorMessage = "Delivery guy's rating must be between 1 and 5.")]
        public Rating rating { get; set; } = Rating.Excellent;

        [Range(0, 2, ErrorMessage = "Delivery guy's status type must be between 0 and 3.")]
        public Status status { get; set; } = Status.Available;

        [Required(ErrorMessage = "Delivery guy's CPF is required.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF must have exactly 11 characters.")]
        public required string CPF {  get; set; }
    }
}

