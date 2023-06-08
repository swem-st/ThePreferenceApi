using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.BrandModels.Request;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Brand;
using static ThePreference.Domain.Product.Brand;

namespace ThePreference.Core.Application.UseCases.Brand.Commands;

public class UpdateBrandCommandUseCase: IRequestHandler<UpdateBrandRequestModel, Result>
{
    private readonly ICommandBrandRepository _commandBrandRepository;

    public UpdateBrandCommandUseCase(ICommandBrandRepository commandBrandRepository)
    {
        _commandBrandRepository = commandBrandRepository;
    }
    
    public async Task<Result> Handle(UpdateBrandRequestModel request, CancellationToken cancellationToken)
    {
        var brand = Update(request.Id, request.Name);

        if (brand.IsFailure)
        {
            return Result.Failure(brand.Error);
        }

        var result =  await _commandBrandRepository.UpdateBrand(brand.Value);

        return result;
    }
}