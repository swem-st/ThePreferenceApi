using AutoMapper;
using ThePreference.Core.Application.DTO.ProductModels.Response;

namespace ThePreference.Core.Application.Mappers.Product;

public class ProductDTOMapper: Profile
{
    public ProductDTOMapper()
    {
        CreateMap<Domain.Product.Product, ProductResponseModel>();
    }
}