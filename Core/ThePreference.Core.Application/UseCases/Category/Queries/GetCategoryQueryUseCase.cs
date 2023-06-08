using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.CategoryModels.Request;
using ThePreference.Core.Application.DTO.CategoryModels.Response;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Category;

namespace ThePreference.Core.Application.UseCases.Category.Queries;

public class GetCategoryQueryUseCase: IRequestHandler<GetCategoryRequestModel, Result<CategoryResponseModel>>
{
    private readonly IQueryCategoryRepository _queryCategoryRepository;
    private readonly IMapper _mapper;
    
    public GetCategoryQueryUseCase(IQueryCategoryRepository queryCategoryRepository, IMapper mapper)
    {
        _queryCategoryRepository = queryCategoryRepository;
        _mapper = mapper;
    }

    public async Task<Result<CategoryResponseModel>> Handle(GetCategoryRequestModel request, CancellationToken cancellationToken)
    {
        //This should be in a validator or Domain model
        if (request.Id == Guid.Empty)
        {
            return Result.Failure<CategoryResponseModel>("Category Id cannot be empty");
        }
        
        var category = await _queryCategoryRepository.GetCategory(request.Id);
        
        if (category.IsFailure)
        {
            return Result.Failure<CategoryResponseModel>(category.Error);
        }

        var result = _mapper.Map<CategoryResponseModel>(category.Value);
        return result;
    }
}