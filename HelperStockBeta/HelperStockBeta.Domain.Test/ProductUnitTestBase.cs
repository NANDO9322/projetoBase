using FluentAssertions;
using HelperStockBeta.Domain.Entities;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HelperStockBeta.Domain.Test
{
    public class ProductUnitTestBase
    {
        #region Caso de Testes Positivos
        [Fact(DisplayName = "Product name is not null")]
        public void CreateCategory_WithValidParemeters_ResultValid()
        {
            Action action = () => new Product(1, "Produto Teste", "Descrição Teste", 143, 7, "google.com.br");
            action.Should().NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();

        }
        [Fact(DisplayName = "Product no present id parameter")]
        public void CreateProduct_IdParameterLess_ResultValid()
        {
            Action action = () => new Product(1, "Produto Teste", "Descrição Teste", 143, 7, "google.com.br");
            action.Should().NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion

        #region Casos de Testes Negativos

        [Fact(DisplayName = "Id negative exception.")]
        public void CreateProduct_NegativeParameterId_ResultException()
        {
            Action action = () => new Product(-1, "Produto Teste", "Descrição Teste", 143, 7, "google.com.br");
            action
                .Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid negative values for id.");
        }
        #region Name
        [Fact(DisplayName = "Name in product null")]
        public void CreateProduct_NameParamterNull_ResultException()
        {
            Action action = () => new Product(1, null, "Descrição Teste", 143, 7, "google.com.br");
            action
                .Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Name in product invalid")]
        public void CreateProduct_NameParamterShort_ResultException()
        {
            Action action = () => new Product(1, "Ca", "Descrição Teste", 143, 7, "google.com.br");
            action
                .Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid short names, minimum 3 characteres.");
        }
        #endregion

        #region Description
        [Fact(DisplayName = "Description in product is null.")]
        public void CreateProduct_DescriptionParameterNull_ResultException()
        {
            Action action = () => new Product(1, "Produto Test", null, 143, 7, "google.com.br");
            action
                .Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required.");
        }
        [Fact(DisplayName = "Description in product is invalid.")]
        public void CreateProduct_DescriptionParameterShort_ResultException()
        {
            Action action = () => new Product(1, "Produto Test", "Desc", 143, 7, "google.com.br");
            action
                .Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid short descriptions, minimum 5 characters.");
        }
        #endregion

        #region Price
        [Fact(DisplayName = "Price in product is negative")]
        public void CreateProduct_NegativeParameterPrice_ResultException()
        {
            Action action = () => new Product(1, "Produto Test", "Descrição Teste", -143, 7, "google.com.br");
            action
                .Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid negative values for price.");
        }
        #endregion

        #region Stock
        [Fact(DisplayName = "Product stock is negative")]
        public void CreateProduct_NegativeParameterStock_ResultException()
        {
            Action action = () => new Product(1, "Produto Test", "Descrição Teste", 143, -7, "google.com.br");
            action
                .Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid negative values for stock.");
        }
        #endregion

        #region Image
        [Fact(DisplayName = "Url in product is invalid.")]
        public void CreateCategory_UrlParameterLong_ResultException()
        {
            Action action = () => new Product(1, "Produto Test", "Descrição Teste", 143, 7, "Product Test Product Test Product Test Product Test Product Test Product Test Product Test Product Test Product Test Product Test Product Test Product Test Product Test Product Test Product Test Product Test Product Test Product Test Product Test Prod");
            action
                .Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid long URL, Maximum 250 characteres.");
        }
        #endregion

        #endregion
    }
}