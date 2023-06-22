using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.BrandModels.Request;
using ThePreference.Core.Application.DTO.BrandModels.Response;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Brand;

namespace ThePreference.Core.Application.UseCases.Brand.Queries;

public class GetAllBrandsQueryUseCase: IRequestHandler<GetAllBrandsRequestModel, Result<List<BrandResponseModel>>>
{
    private readonly IQueryBrandRepository _queryBrandRepository;
    private readonly IMapper _mapper;

    public GetAllBrandsQueryUseCase(IQueryBrandRepository queryBrandRepository, IMapper mapper)
    {
        _queryBrandRepository = queryBrandRepository;
        _mapper = mapper;
    }
    
    public async Task<Result<List<BrandResponseModel>>> Handle(GetAllBrandsRequestModel request, CancellationToken cancellationToken)
    {
        var brand = await _queryBrandRepository.GetAllBrands();
        
        if (brand.IsFailure)
        {
            return Result.Failure<List<BrandResponseModel>>(brand.Error);
        }

        var result = _mapper.Map<List<BrandResponseModel>>(brand.Value);
        return result;
    }
}