using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ColorModels.Request;
using ThePreference.Core.Application.DTO.ColorModels.Response;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Color;

namespace ThePreference.Core.Application.UseCases.Color.Queries;

public class GetAllColorsQueryUseCase: IRequestHandler<GetAllColorsRequestModel, Result<List<ColorResponseModel>>>
{
    private readonly IQueryColorRepository _queryColorRepository;
    private readonly IMapper _mapper;

    public GetAllColorsQueryUseCase(IQueryColorRepository queryColorRepository, IMapper mapper)
    {
        _queryColorRepository = queryColorRepository;
        _mapper = mapper;
    }
    
    public async Task<Result<List<ColorResponseModel>>> Handle(GetAllColorsRequestModel request, CancellationToken cancellationToken)
    {
        var colors = await _queryColorRepository.GetAllColors();
        
        if (colors.IsFailure)
        {
            return Result.Failure<List<ColorResponseModel>>(colors.Error);
        }

        var result = _mapper.Map<List<ColorResponseModel>>(colors.Value);
        return result;
    }
}