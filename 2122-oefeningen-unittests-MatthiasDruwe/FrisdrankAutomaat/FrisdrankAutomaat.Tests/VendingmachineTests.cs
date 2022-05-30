using NUnit.Framework;
using System;

namespace FrisdrankAutomaat.Tests
{
    internal class VendingmachineTests
    {
        [Test]
        public void AddDrink_WithCertainDrinkOnPosition_AddsDrink()
        {
            // Arrange
            Vendingmachine sut = new Vendingmachine();
            Drink drink = new Drink("Fanta", 2.5);
            int row = 1;
            int column = 2;

            // Act
            sut.AddDrink(drink, row, column);

            // Assert

            Assert.AreEqual(drink, sut.Inventory[(row, column)]);
        }



        [Test]
        public void Buy_WithRowToHight_ThrowsIndexOutOfRangeException()
        {
            // Arrange
            Vendingmachine sut = new Vendingmachine();
            int row = 11;
            int col = 10;

            // Act + Assert

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                Drink result = sut.buy(row, col);
            });

        }

        [Test]
        public void Buy_WithNotEnoughMoney_ThrowsNotEnougMoneyException()
        {
            // Arrange
            Vendingmachine sut = new Vendingmachine();
            int row = 1;
            int col = 2;
            Drink drink = new Drink("Fanta", 2.5);
            sut.AddDrink(drink, row, col);
            sut.InsertCoins(Coins.FIFTYCENTS);

            // Act + Assert

            Assert.Throws<NotEnougMoneyException>(() =>
            {
                Drink result = sut.buy(row, col);
            });

        }

        [Test]
        public void InsertCoins_With2Euro_BudgetHas2Euro()
        {
            // Arrange
            Vendingmachine sut = new Vendingmachine();


            // Act
            sut.InsertCoins(Coins.TWOEURO);

            // Assert
            Assert.AreEqual(2, sut.Budget);

        }
    }
}
