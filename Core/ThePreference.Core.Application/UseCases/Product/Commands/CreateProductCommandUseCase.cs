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

public class CreateProductCommandUseCase : IRequestHandler<CreateProductRequestModel, Result>
{
    private readonly ICommandProductRepository _commandProductRepository;
    private readonly IMapper _mapper;

    public CreateProductCommandUseCase(ICommandProductRepository commandProductRepository, IMapper mapper)
    {
        _commandProductRepository = commandProductRepository;
        _mapper = mapper;
    }

    public async Task<Result> Handle(CreateProductRequestModel request, CancellationToken cancellationToken)
    {
        var categories = new List<CategoryDomain>();
        
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
        
        var colors = new List<ColorDomain>();
        
        foreach (var color in request.Colors)
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

            colors.Add(colorDomain.Value);
        }
        
        var images = new List<ImageDomain>();
        
        foreach (var image in request.Images)
        {
            var imageDomain = ImageDomain.Create(
                image.ImageUrl,
                image.AltText);

            if (imageDomain.IsFailure)
            {
                return Result.Failure(imageDomain.Error);
            }

            images.Add(imageDomain.Value);
        }
        
        var product = Create(
            request.Name,
            request.Title,
            request.Description,
            request.Price,
            request.Model,
            categories,
            images,
            colors);

        if (product.IsFailure)
        {
            return Result.Failure(product.Error);
        }

        var brand = BrandDomain.Update(
            request.Brand.Id,
            request.Brand.Name);

        if (brand.IsFailure)
        {
            return Result.Failure(brand.Error);
        }
        
        product.Value.Brand = brand.Value;

        var result = await _commandProductRepository.CreateProduct(product.Value);
        return result;
    }
}