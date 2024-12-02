namespace AdminAppProducts.Tests;

using System;
using Xunit;
using AdminAppProducts;

public class PriceManagementTests
{
    [Fact]
    public void UpdatePrice_ShouldUpdatePrice_WhenValidDataProvided()
    {
        // Arrange
        var repository = new ProductRepository();
        var productId = 1;
        var newPrice = 1200;

        // Act
        repository.UpdatePrice(productId, newPrice);
        var updatedProduct = repository.GetProducts().First(p => p.Id == productId);

        // Assert
        Assert.Equal(newPrice, updatedProduct.Price);
    }

    [Fact]
    public void UpdatePrice_ShouldThrowArgumentException_WhenPriceIsZeroOrNegative()
    {
        // Arrange
        var repository = new ProductRepository();
        var productId = 1;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => repository.UpdatePrice(productId, 0));
        Assert.Throws<ArgumentException>(() => repository.UpdatePrice(productId, -100));
    }

    [Fact]
    public void UpdatePrice_ShouldThrowKeyNotFoundException_WhenProductDoesNotExist()
    {
        // Arrange
        var repository = new ProductRepository();
        var invalidProductId = 999;

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => repository.UpdatePrice(invalidProductId, 1000));
    }
}
