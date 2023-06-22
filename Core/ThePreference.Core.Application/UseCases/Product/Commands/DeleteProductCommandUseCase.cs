using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ProductModels.Request;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Product;

namespace ThePreference.Core.Application.UseCases.Product.Commands;

public class DeleteProductCommandUseCase: IRequestHandler<DeleteProductRequestModel, Result>
{
    private readonly ICommandProductRepository _commandProductRepository;
    private readonly IMapper _mapper;

    public DeleteProductCommandUseCase(ICommandProductRepository commandProductRepository, IMapper mapper)
    {
        _commandProductRepository = commandProductRepository;
        _mapper = mapper;
    }
    
    public async Task<Result> Handle(DeleteProductRequestModel request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return Result.Failure("Category Id cannot be empty");
        }
        
        var result = await _commandProductRepository.DeleteProduct(request.Id);
        return result;
    }
}