using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.BrandModels.Response;

namespace ThePreference.Core.Application.DTO.BrandModels.Request;

public class GetBrandRequestModel: IRequest<Result<BrandResponseModel>>
{
    public GetBrandRequestModel(Guid brandId)
    {
        Id = brandId;
    }
    
    public Guid Id { get; set; }
}