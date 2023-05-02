using MediatR;
using ThePreference.Application.DTO.ProductModels.Request;
using ThePreference.Application.DTO.ProductModels.Response;
using ThePreference.Application.DTO.Wrappers;

namespace ThePreference.Application.UseCases.Product.Queries;

public class GetProductQueryUseCase: IRequestHandler<GetProductRequestModel, Response<ProductResponseModel>>
{
    //private readonly IProductRepository _productRepository;
    // private readonly IMapper _mapper;
    // public GetProductByIdQueryUseCase(IProductRepository productRepository, IMapper mapper)
    // {
    //     _productRepository = productRepository;
    //     _mapper = mapper;
    // }
    public GetProductQueryUseCase()
    {
        
    }
    
    public async Task<Response<ProductResponseModel>> Handle(GetProductRequestModel request, CancellationToken cancellationToken)
    {
        //var userObject = (await _userRepository.FindByCondition(x => x.UserId.Equals(request.UserId)).ConfigureAwait(false)).AsQueryable().FirstOrDefault();
        return new Response<ProductResponseModel>();
    }
}