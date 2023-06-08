using MediatR;
using ThePreference.Application.DTO.ProductModels.Request;
using ThePreference.Application.DTO.Wrappers;
using static ThePreference.Domain.Product.Product;

namespace ThePreference.Application.UseCases.Product.Commands;

public class CreateProductCommandUseCase: IRequestHandler<CreateProductRequestModel, Response<Guid>>
{
    //private readonly IProductRepository _productRepository;
    // private readonly IMapper _mapper;
    // public GetProductByIdQueryUseCase(IProductRepository productRepository, IMapper mapper)
    // {
    //     _productRepository = productRepository;
    //     _mapper = mapper;
    // }
    public CreateProductCommandUseCase()
    {
        
    }
    
    public async Task<Response<Guid>> Handle(CreateProductRequestModel request, CancellationToken cancellationToken)
    {
        var result = Create(
            request.Name,
            request.Title,
            request.Description,
            request.Price,
            request.CategoryId,
            request.BrandId,
            request.Images,
            request.Colors);
        
        

        //var userObject = (await _userRepository.FindByCondition(x => x.UserId.Equals(request.UserId)).ConfigureAwait(false)).AsQueryable().FirstOrDefault();
        return new Response<Guid>();
    }
}