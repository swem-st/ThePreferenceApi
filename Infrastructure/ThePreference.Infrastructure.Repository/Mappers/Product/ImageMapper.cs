using AutoMapper;
using ThePreference.Domain.Product;
using ThePreference.Infrastructure.Repository.DataModels.Product;

namespace ThePreference.Infrastructure.Repository.Mappers.Product;

public class ImageMapper: Profile
{
    public ImageMapper()
    {
        CreateMap<Image, ImageEntity>()
            .ForMember(src => src.ProductId, opt => opt.PreCondition(src => src.ProductId != Guid.Empty)).ReverseMap();
        
     //   CreateMap<List<ImageEntity>, List<Image>>();
    }
}