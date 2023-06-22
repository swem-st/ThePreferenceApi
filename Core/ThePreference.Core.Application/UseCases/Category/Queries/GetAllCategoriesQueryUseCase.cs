using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.CategoryModels.Request;
using ThePreference.Core.Application.DTO.CategoryModels.Response;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Category;

namespace ThePreference.Core.Application.UseCases.Category.Queries;

public class GetAllCategoriesQueryUseCase: IRequestHandler<GetAllCategoriesRequestModel, Result<List<CategoryResponseModel>>>
{
    private readonly IQueryCategoryRepository _queryCategoryRepository;
    private readonly IMapper _mapper;
    
    public GetAllCategoriesQueryUseCase(IQueryCategoryRepository queryCategoryRepository, IMapper mapper)
    {
        _queryCategoryRepository = queryCategoryRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<CategoryResponseModel>>> Handle(GetAllCategoriesRequestModel request, CancellationToken cancellationToken)
    {
        var categories = await _queryCategoryRepository.GetAllCategories();
        
        if (categories.IsFailure)
        {
            return Result.Failure<List<CategoryResponseModel>>(categories.Error);
        }

        var result = _mapper.Map<List<CategoryResponseModel>>(categories.Value);
        return result;
    }
}