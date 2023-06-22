using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ProductModels.Request;
using ThePreference.Core.Application.DTO.ProductModels.Response;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Product;

namespace ThePreference.Core.Application.UseCases.Product.Queries;

public class GetProductQueryUseCase: IRequestHandler<GetProductRequestModel, Result<ProductResponseModel>>
{
    private readonly IQueryProductRepository _queryProductRepository;
    private readonly IMapper _mapper;
    
    public GetProductQueryUseCase(IQueryProductRepository queryProductRepository, IMapper mapper)
    {
        _queryProductRepository = queryProductRepository;
        _mapper = mapper;
    }

    public async Task<Result<ProductResponseModel>> Handle(GetProductRequestModel request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return Result.Failure<ProductResponseModel>("Product Id cannot be empty");
        }
        
        var product = await _queryProductRepository.GetProduct(request.Id);
        
        if (product.IsFailure)
        {
            return Result.Failure<ProductResponseModel>(product.Error);
        }
        
        var result = _mapper.Map<ProductResponseModel>(product.Value);
        return result;
    }
}