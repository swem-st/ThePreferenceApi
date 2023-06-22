using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ImageModels.Request;
using ThePreference.Core.Application.DTO.ImageModels.Response;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Image;

namespace ThePreference.Core.Application.UseCases.Image.Queries;

public class GetImageQueryUseCase: IRequestHandler<GetImageRequestModel, Result<ImageResponseModel>>
{
    private readonly IQueryImageRepository _queryImageRepository;
    private readonly IMapper _mapper;

    public GetImageQueryUseCase(IQueryImageRepository queryImageRepository, IMapper mapper)
    {
        _queryImageRepository = queryImageRepository;
        _mapper = mapper;
    }
    
    public async Task<Result<ImageResponseModel>> Handle(GetImageRequestModel request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return Result.Failure<ImageResponseModel>("Image Id cannot be empty");
        }
        
        var image = await _queryImageRepository.GetImage(request.Id);
        
        if (image.IsFailure)
        {
            return Result.Failure<ImageResponseModel>(image.Error);
        }

        var result = _mapper.Map<ImageResponseModel>(image.Value);
        return result;
    }
}