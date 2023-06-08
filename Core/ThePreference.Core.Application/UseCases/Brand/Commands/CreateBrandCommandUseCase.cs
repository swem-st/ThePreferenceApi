using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.BrandModels.Request;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Brand;
using static ThePreference.Domain.Product.Brand;

namespace ThePreference.Core.Application.UseCases.Brand.Commands;

public class CreateBrandCommandUseCase : IRequestHandler<CreateBrandRequestModel, Result>
{
    private readonly ICommandBrandRepository _commandBrandRepository;

    public CreateBrandCommandUseCase(ICommandBrandRepository commandBrandRepository)
    {
        _commandBrandRepository = commandBrandRepository;
    }

    public async Task<Result> Handle(CreateBrandRequestModel request, CancellationToken cancellationToken)
    {
        var brand = Create(request.Name);

        if (brand.IsFailure)
        {
            return Result.Failure(brand.Error);
        }

        var result =  await _commandBrandRepository.CreateBrand(brand.Value);

        return result;
    }
}