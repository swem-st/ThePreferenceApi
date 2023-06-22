using AutoMapper;
using ThePreference.Domain.Product;
using ThePreference.Infrastructure.Repository.DataModels.Product;

namespace ThePreference.Infrastructure.Repository.Mappers.Product;

public class ColorMapper: Profile
{
    public ColorMapper()
    {
        CreateMap<Color, ColorEntity>().ReverseMap();
    }
}