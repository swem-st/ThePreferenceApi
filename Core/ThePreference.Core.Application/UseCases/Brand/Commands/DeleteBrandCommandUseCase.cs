using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Application.DTO.Wrappers;
using ThePreference.Core.Application.DTO.BrandModels.Request;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Brand;

namespace ThePreference.Core.Application.UseCases.Brand.Commands;

public class DeleteBrandCommandUseCase: IRequestHandler<DeleteBrandRequestModel, Result>
{
    private readonly ICommandBrandRepository _commandBrandRepository;

    public DeleteBrandCommandUseCase(ICommandBrandRepository commandBrandRepository)
    {
        _commandBrandRepository = commandBrandRepository;
    }
    
    public async Task<Result> Handle(DeleteBrandRequestModel request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return Result.Failure("Brand Id cannot be empty");
        }
        
        var result =  await _commandBrandRepository.DeleteBrand(request.Id);
        return result;
    }
}