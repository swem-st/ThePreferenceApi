using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.CategoryModels.Request;
using ThePreference.Core.Application.DTO.CategoryModels.Response;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Category;

namespace ThePreference.Core.Application.UseCases.Category.Queries;

public class GetAllCategoryQueryUseCase: IRequestHandler<GetAllCategoryRequestModel, Result<List<CategoryResponseModel>>>
{
    private readonly IQueryCategoryRepository _queryCategoryRepository;
    private readonly IMapper _mapper;
    
    public GetAllCategoryQueryUseCase(IQueryCategoryRepository queryCategoryRepository, IMapper mapper)
    {
        _queryCategoryRepository = queryCategoryRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<CategoryResponseModel>>> Handle(GetAllCategoryRequestModel request, CancellationToken cancellationToken)
    {
        var category = await _queryCategoryRepository.GetAllCategories();
        
        if (category.IsFailure)
        {
            return Result.Failure<List<CategoryResponseModel>>(category.Error);
        }

        var result = _mapper.Map<List<CategoryResponseModel>>(category.Value);
        return result;
    }
}