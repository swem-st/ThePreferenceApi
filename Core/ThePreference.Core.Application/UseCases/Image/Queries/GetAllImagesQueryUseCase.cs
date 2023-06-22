using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ImageModels.Request;
using ThePreference.Core.Application.DTO.ImageModels.Response;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Image;

namespace ThePreference.Core.Application.UseCases.Image.Queries;

public class GetAllImagesQueryUseCase: IRequestHandler<GetAllImagesRequestModel, Result<List<ImageResponseModel>>>
{
    private readonly IQueryImageRepository _queryImageRepository;
    private readonly IMapper _mapper;

    public GetAllImagesQueryUseCase(IQueryImageRepository queryImageRepository, IMapper mapper)
    {
        _queryImageRepository = queryImageRepository;
        _mapper = mapper;
    }
    
    public async Task<Result<List<ImageResponseModel>>> Handle(GetAllImagesRequestModel request, CancellationToken cancellationToken)
    {
        var images = await _queryImageRepository.GetAllImages();
        
        if (images.IsFailure)
        {
            return Result.Failure<List<ImageResponseModel>>(images.Error);
        }

        var result = _mapper.Map<List<ImageResponseModel>>(images.Value);
        return result;
    }
}