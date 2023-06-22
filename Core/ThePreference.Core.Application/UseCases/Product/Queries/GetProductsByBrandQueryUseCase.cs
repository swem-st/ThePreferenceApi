using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ProductModels.Request;
using ThePreference.Core.Application.DTO.ProductModels.Response;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Product;

namespace ThePreference.Core.Application.UseCases.Product.Queries;

public class GetProductsByBrandQueryUseCase: IRequestHandler<GetProductsByBrandRequestModel,  Result<List<ProductResponseModel>>>
{
    private readonly IQueryProductRepository _queryProductRepository;
    private readonly IMapper _mapper;
    
    public GetProductsByBrandQueryUseCase(IQueryProductRepository queryProductRepository, IMapper mapper)
    {
        _queryProductRepository = queryProductRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<ProductResponseModel>>> Handle(GetProductsByBrandRequestModel request, CancellationToken cancellationToken)
    {
        if (request.BrandId == Guid.Empty)
        {
            return Result.Failure<List<ProductResponseModel>>("Brand Id cannot be empty");
        }
        
        var product = await _queryProductRepository.GetProductsByBrand(request.BrandId);
        
        if (product.IsFailure)
        {
            return Result.Failure<List<ProductResponseModel>>(product.Error);
        }
        
        var result = _mapper.Map<List<ProductResponseModel>>(product.Value);
        return result;
    }
}