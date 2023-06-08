using AutoMapper;
using ThePreference.Domain.Product;
using ThePreference.Infrastructure.Repository.DataModels.Product;

namespace ThePreference.Infrastructure.Repository.Mappers.Product;

public class CategoryMapper: Profile
{
    public CategoryMapper()
    {
        CreateMap<Category, CategoryEntity>();
    }
}