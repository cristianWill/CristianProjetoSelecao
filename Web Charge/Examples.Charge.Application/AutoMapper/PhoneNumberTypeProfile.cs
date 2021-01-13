using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.AutoMapper
{
    public class PhoneNumberTypeProfile : Profile
    {
        public PhoneNumberTypeProfile()
        {
            CreateMap<PhoneNumberType, PhoneNumberTypeDto>()
               .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.PhoneNumberTypeID))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ReverseMap()
               .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.BusinessEntityID));
        }
    }
}
