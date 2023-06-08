using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.BrandModels.Request;
using ThePreference.Core.Application.DTO.BrandModels.Response;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Brand;

namespace ThePreference.Core.Application.UseCases.Brand.Queries;

public class GetBrandQueryUseCase: IRequestHandler<GetBrandRequestModel, Result<BrandResponseModel>>
{
    private readonly IQueryBrandRepository _queryBrandRepository;
    private readonly IMapper _mapper;

    public GetBrandQueryUseCase(IQueryBrandRepository queryBrandRepository, IMapper mapper)
    {
        _queryBrandRepository = queryBrandRepository;
        _mapper = mapper;
    }
    
    public async Task<Result<BrandResponseModel>> Handle(GetBrandRequestModel request, CancellationToken cancellationToken)
    {
        //This should be in a validator or Domain model
        if (request.Id == Guid.Empty)
        {
            return Result.Failure<BrandResponseModel>("Brand Id cannot be empty");
        }
        
        var brand = await _queryBrandRepository.GetBrand(request.Id);
        
        if (brand.IsFailure)
        {
            return Result.Failure<BrandResponseModel>(brand.Error);
        }

        var result = _mapper.Map<BrandResponseModel>(brand.Value);
        return result;
    }
}