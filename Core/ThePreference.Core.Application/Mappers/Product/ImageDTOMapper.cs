using AutoMapper;
using ThePreference.Core.Application.DTO.ImageModels;
using ThePreference.Core.Application.DTO.ImageModels.Response;
using ThePreference.Domain.Product;

namespace ThePreference.Core.Application.Mappers.Product;

public class ImageDTOMapper: Profile
{
    public ImageDTOMapper()
    {
        CreateMap<Image, ImageResponseModel>();
        CreateMap<Image, ImageDTO>();
    }
}