using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ProductModels.Request;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Product;
using static ThePreference.Domain.Product.Product;
using CategoryDomain = ThePreference.Domain.Product.Category;
using BrandDomain = ThePreference.Domain.Product.Brand;
using ImageDomain = ThePreference.Domain.Product.Image;
using ColorDomain = ThePreference.Domain.Product.Color;

namespace ThePreference.Core.Application.UseCases.Product.Commands;

public class UpdateProductCommandUseCase: IRequestHandler<UpdateProductRequestModel, Result>
{
    private readonly ICommandProductRepository _commandProductRepository;
    private readonly IMapper _mapper;

    public UpdateProductCommandUseCase(ICommandProductRepository commandProductRepository, IMapper mapper)
    {
        _commandProductRepository = commandProductRepository;
        _mapper = mapper;
    }

    public async Task<Result> Handle(UpdateProductRequestModel request, CancellationToken cancellationToken)
    {
        var categories = new List<CategoryDomain>();
        if (request.IsCategoriesHaveChanged)
        {
            foreach (var category in request.Categories)
            {
                var categoryDomain = CategoryDomain.Update(
                    category.Id,
                    category.Name);
            
                if (categoryDomain.IsFailure)
                {
                    return Result.Failure(categoryDomain.Error);
                }

                categories.Add(categoryDomain.Value);
            }
        }
        
        var product = Update(
            request.Id,
            request.Name,
            request.Title,
            request.Description,
            request.Price,
            request.Model,
            categories,
            request.IsCategoriesHaveChanged,
            request.DeletedColors);

        if (product.IsFailure)
        {
            return Result.Failure(product.Error);
        }
        
        if (request.NewImages != null)
        {
            foreach (var image in request.NewImages)
            {
                var imageDomain = ImageDomain.Create(
                    image.ImageUrl,
                    image.AltText);

                if (imageDomain.IsFailure)
                {
                    return Result.Failure(imageDomain.Error);
                }

                product.Value.Images.Add(imageDomain.Value);
            }
        }
        
        if (request.NewColors != null)
        {
            foreach (var color in request.NewColors)
            {
                var colorDomain = ColorDomain.Update(
                    color.Id,
                    color.IsBasic,
                    color.Name,
                    color.Code);

                if (colorDomain.IsFailure)
                {
                    return Result.Failure(colorDomain.Error);
                }

                product.Value.Colors.Add(colorDomain.Value);
            }
        }

        var brand = BrandDomain.Update(
            request.Brand.Id,
            request.Brand.Name);

        if (brand.IsFailure)
        {
            return Result.Failure(brand.Error);
        }
        
        product.Value.Brand = brand.Value;

        var result = await _commandProductRepository.UpdateProduct(product.Value);
        return result;
    }
}