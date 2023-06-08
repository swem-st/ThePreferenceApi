using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.BrandModels.Request;

public class DeleteBrandRequestModel: IRequest<Result>
{
    public DeleteBrandRequestModel(Guid brandId)
    {
        Id = brandId;
    }
    
    public Guid Id { get; }
}