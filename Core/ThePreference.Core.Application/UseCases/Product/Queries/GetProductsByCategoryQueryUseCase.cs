using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ProductModels.Request;
using ThePreference.Core.Application.DTO.ProductModels.Response;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Product;

namespace ThePreference.Core.Application.UseCases.Product.Queries;

public class GetProductsByCategoryQueryUseCase: IRequestHandler<GetProductsByCategoryRequestModel,  Result<List<ProductResponseModel>>>
{
    private readonly IQueryProductRepository _queryProductRepository;
    private readonly IMapper _mapper;
    
    public GetProductsByCategoryQueryUseCase(IQueryProductRepository queryProductRepository, IMapper mapper)
    {
        _queryProductRepository = queryProductRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<ProductResponseModel>>> Handle(GetProductsByCategoryRequestModel request, CancellationToken cancellationToken)
    {
        if (request.CategoryId == Guid.Empty)
        {
            return Result.Failure<List<ProductResponseModel>>("Category Id cannot be empty");
        }
        
        var product = await _queryProductRepository.GetProductsByCategory(request.CategoryId);
        
        if (product.IsFailure)
        {
            return Result.Failure<List<ProductResponseModel>>(product.Error);
        }
        
        var result = _mapper.Map<List<ProductResponseModel>>(product.Value);
        return result;
    }
}