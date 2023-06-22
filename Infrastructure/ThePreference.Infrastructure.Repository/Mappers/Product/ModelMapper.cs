using AutoMapper;
using ThePreference.Domain.Product;
using ThePreference.Infrastructure.Repository.DataModels.Product;

namespace ThePreference.Infrastructure.Repository.Mappers.Product;

public class ModelMapper: Profile
{
    public ModelMapper()
    {
        CreateMap<Model, ModelEntity>().ReverseMap();
    }
}