using AutoMapper;
using ThePreference.Core.Application.DTO.CategoryModels.Response;
using ThePreference.Domain.Product;

namespace ThePreference.Core.Application.Mappers.Product;

public class CategoryDTOMapper: Profile
{
    public CategoryDTOMapper()
    {
        CreateMap<Category, CategoryResponseModel>();
    }
}