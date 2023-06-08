using AutoMapper;
using ThePreference.Core.Application.DTO.BrandModels.Response;
using ThePreference.Domain.Product;

namespace ThePreference.Core.Application.Mappers.Product;

public class BrandDTOMapper: Profile
{
    public BrandDTOMapper()
    {
        CreateMap<Brand, BrandResponseModel>();
    }
}