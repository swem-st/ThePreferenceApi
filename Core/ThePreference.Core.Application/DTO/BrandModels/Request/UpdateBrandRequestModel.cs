using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.BrandModels.Request;

public class UpdateBrandRequestModel: BrandDTO, IRequest<Result>
{
    
}