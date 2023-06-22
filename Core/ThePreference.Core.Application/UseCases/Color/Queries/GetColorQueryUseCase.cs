using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ColorModels.Request;
using ThePreference.Core.Application.DTO.ColorModels.Response;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Color;

namespace ThePreference.Core.Application.UseCases.Color.Queries;

public class GetColorQueryUseCase: IRequestHandler<GetColorRequestModel, Result<ColorResponseModel>>
{
    private readonly IQueryColorRepository _queryColorRepository;
    private readonly IMapper _mapper;

    public GetColorQueryUseCase(IQueryColorRepository queryColorRepository, IMapper mapper)
    {
        _queryColorRepository = queryColorRepository;
        _mapper = mapper;
    }
    
    public async Task<Result<ColorResponseModel>> Handle(GetColorRequestModel request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return Result.Failure<ColorResponseModel>("Color Id cannot be empty");
        }
        
        var color = await _queryColorRepository.GetColor(request.Id);
        
        if (color.IsFailure)
        {
            return Result.Failure<ColorResponseModel>(color.Error);
        }

        var result = _mapper.Map<ColorResponseModel>(color.Value);
        return result;
    }
}