using MediatR;
using ThePreference.Application.DTO.ProductModels.Request;
using ThePreference.Application.DTO.Wrappers;

namespace ThePreference.Application.UseCases.Product.Commands;

public class DeleteProductCommandUseCase: IRequestHandler<DeleteProductRequestModel, Response<Guid>>
{
    //private readonly IProductRepository _productRepository;
    // private readonly IMapper _mapper;
    // public GetProductByIdQueryUseCase(IProductRepository productRepository, IMapper mapper)
    // {
    //     _productRepository = productRepository;
    //     _mapper = mapper;
    // }
    public DeleteProductCommandUseCase()
    {
        
    }
    
    public async Task<Response<Guid>> Handle(DeleteProductRequestModel request, CancellationToken cancellationToken)
    {
        //var userObject = (await _userRepository.FindByCondition(x => x.UserId.Equals(request.UserId)).ConfigureAwait(false)).AsQueryable().FirstOrDefault();
        return new Response<Guid>();
    }
}