using AutoMapper;
using ThePreference.Core.Application.DTO.ColorModels;
using ThePreference.Core.Application.DTO.ColorModels.Response;
using ThePreference.Domain.Product;

namespace ThePreference.Core.Application.Mappers.Product;

public class ColorDTOMapper: Profile
{
    public ColorDTOMapper()
    {
        CreateMap<Color, ColorResponseModel>();
        CreateMap<Color, ColorDTO>();
    }
}