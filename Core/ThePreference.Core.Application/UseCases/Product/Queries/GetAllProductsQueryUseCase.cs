using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ProductModels.Request;
using ThePreference.Core.Application.DTO.ProductModels.Response;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Product;

namespace ThePreference.Core.Application.UseCases.Product.Queries;

public class GetAllProductsQueryUseCase: IRequestHandler<GetAllProductsRequestModel,  Result<List<ProductResponseModel>>>
{
    private readonly IQueryProductRepository _queryProductRepository;
    private readonly IMapper _mapper;
    
    public GetAllProductsQueryUseCase(IQueryProductRepository queryProductRepository, IMapper mapper)
    {
        _queryProductRepository = queryProductRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<ProductResponseModel>>> Handle(GetAllProductsRequestModel request, CancellationToken cancellationToken)
    {
        var products = await _queryProductRepository.GetAllProducts();
        
        if (products.IsFailure)
        {
            return Result.Failure<List<ProductResponseModel>>(products.Error);
        }
        
        var result = _mapper.Map<List<ProductResponseModel>>(products.Value);
        return result;
    }
}