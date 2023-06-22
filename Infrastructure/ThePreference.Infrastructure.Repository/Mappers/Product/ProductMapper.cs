using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ThePreference.Domain.Product;
using ThePreference.Infrastructure.Repository.DataModels.Product;

namespace ThePreference.Infrastructure.Repository.Mappers.Product;

public class ProductMapper: Profile
{
    public ProductMapper()
    {
        CreateMap<Domain.Product.Product, ProductEntity>()
            .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Brand.Id))
            .ForMember(dest => dest.Brand, opt => opt.Ignore())
            .ForMember(dest => dest.Model, opt => opt.Condition((src, dest) =>  src.Model != null && src.Model.Name != dest.Model?.Name))
            .ForMember(dest => dest.ProductCategories, opt =>
            {
                opt.PreCondition(src => src.IsCategoriesHaveChanged);
                opt.MapFrom(src => src.Categories);
            })
            .ForMember(dest => dest.ProductsColors, opt =>
            {
                opt.PreCondition(src => !src.IsUpdate);
                opt.MapFrom(src => src.Colors);
            })
            .ForMember(src => src.Images, opt =>
                opt.PreCondition(src => !src.IsUpdate));
        
        CreateMap<Category, ProductCategoryEntity>()
            .ForMember(dest => dest.CategoryId, opt =>
                opt.MapFrom(src => src.Id));
        
        CreateMap<Color, ProductColorEntity>()
            .ForPath(dest => dest.ColorId, opt => 
                opt.MapFrom(src => src.Id));
    }
}