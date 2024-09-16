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

        #endregion

        # region Teste Negativos de Categoria
        [Fact(DisplayName = "Create Category With Invalid State")]
        public void Create_Category_WithInvalidParametersId_ResultExeption()
        {
            Action action = () => new Category(-1, "Category name");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id Value");
        }
        #endregion
    }
}
