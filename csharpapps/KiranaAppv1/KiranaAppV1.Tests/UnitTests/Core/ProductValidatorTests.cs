using FluentValidation.TestHelper;
using KiranaAppV1.Core.DTOs;
using KiranaAppV1.Core.DTOs.Requests;
using KiranaAppV1.Core.DTOs.Validators;

public class ProductValidatorTests(ProductRequestValidator validationRules)
{
    private readonly ProductRequestValidator _validator = validationRules;

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        var model = new ProductRequestDTO{Name= ""};
        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }
}