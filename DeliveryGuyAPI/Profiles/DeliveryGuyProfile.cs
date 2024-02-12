using AutoMapper;
using DeliveryGuyAPI.Data.Dtos;
using DeliveryGuyAPI.Models;

namespace DeliveryGuyAPI.Profiles
{
    public class DeliveryGuyProfile : Profile
    {
        public DeliveryGuyProfile()
        {
            CreateMap<DeliveryGuy, ReadDeliveryGuyDto>();
            CreateMap<CreateDeliveryGuyDto, DeliveryGuy>();
        }
    }
}
