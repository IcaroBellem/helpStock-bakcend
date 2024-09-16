using HelpStockApp.Domain.Entities;
using FluentAssertions;
using Xunit;
using HelpStockApp.Domain.Validation;

namespace HelpStockApp.Domain.Test
{
    #region Teste Positivos de Categoria
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void Create_Category_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Create Category With Category Name Alone Parameters")]
        public void Create_Category_WithNameALoneParameters_ResultObjectValidState()
        {
            Action action = () => new Category("Category name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        # region Teste Negativos de Categoria
        [Fact(DisplayName = "Create Category With Invalid State")]
        public void Create_Category_WithInvalidParametersId_ResultExeption()
        {
            Action action = () => new Category(-1, "Category name");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id Value");
        }

        [Fact(DisplayName = "Create Category With Too Short Parameters")]
        public void Create_Category_WithTooShortParameters_ResultExeption()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short. minimum 3 characters");
        }

        [Fact(DisplayName = "Create Category With null Parameters")]
        public void Create_Category_WithNullParameters_ResultExeption()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required");
        }

        [Fact(DisplayName = "Create Category With Name missing Parameters")]
        public void Create_Category_WithNameMissingParameters_ResultExeption()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required");
        }

        [Fact(DisplayName = "Create Category With invalid Id Parameters")]
        public void Create_Category_WithInvalidIdParameters_ResultExeption()
        {
            Action action = () => new Category('a', "Category");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id");
        }

        #endregion
    }
}
