using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ImageModels.Request;
using ThePreference.Core.Application.DTO.ImageModels.Response;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Image;

namespace ThePreference.Core.Application.UseCases.Image.Queries;

public class GetImagesByProductQueryUseCase: IRequestHandler<GetImagesByProductRequestModel, Result<List<ImageResponseModel>>>
{
    private readonly IQueryImageRepository _queryImageRepository;
    private readonly IMapper _mapper;

    public GetImagesByProductQueryUseCase(IQueryImageRepository queryImageRepository, IMapper mapper)
    {
        _queryImageRepository = queryImageRepository;
        _mapper = mapper;
    }
    
    public async Task<Result<List<ImageResponseModel>>> Handle(GetImagesByProductRequestModel request, CancellationToken cancellationToken)
    {
        if (request.ProductId == Guid.Empty)
        {
            return Result.Failure<List<ImageResponseModel>>("Product Id cannot be empty");
        }

        var images = await _queryImageRepository.GetImagesByProduct(request.ProductId);
        
        if (images.IsFailure)
        {
            return Result.Failure<List<ImageResponseModel>>(images.Error);
        }

        var result = _mapper.Map<List<ImageResponseModel>>(images.Value);
        return result;
    }
}