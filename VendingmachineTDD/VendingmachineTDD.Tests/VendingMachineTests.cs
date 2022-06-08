using NUnit.Framework;

namespace VendingmachineTDD.Tests
{
    internal class VendingMachineTests
    {
        [Test]
        public void Add2EuroToMachine_BudgetIs2Euro()
        {
            VendingMachine sut = new VendingMachine();

            sut.Add2Euro();

            Assert.AreEqual(2, sut.Budget);
        }


        [Test]
        public void Add1EuroToMachine_BudgetIs1Euro()
        {
            VendingMachine sut = new VendingMachine();
            sut.Add1Euro();

            Assert.AreEqual(1, sut.Budget);
        }

        [Test]
        public void Add1Euro_WithAlreadyExistingBudgetOf3_BudgetIs4()
        {
            VendingMachine sut = new VendingMachine();
            sut.Budget = 3;

            sut.Add1Euro();

            Assert.AreEqual(4, sut.Budget);
        }

        [Test]
        public void Add1EuroAnd2Euro_BudgetIs3Euro()
        {
            VendingMachine sut = new VendingMachine();


            sut.Add1Euro();
            sut.Add2Euro();

            Assert.AreEqual(3, sut.Budget);
        }

        [Test]
        public void BudgetUpdates_OnPropertyChangedEventIsCalled()
        {
            VendingMachine sut = new VendingMachine();

            sut.PropertyChanged += (e, args) =>
            {

                Assert.AreEqual("Budget", args.PropertyName);
                Assert.Pass();
            };

            sut.Budget = 5;

            Assert.Fail();
        }

        [Test]
        public void Refund_WithBudgetOf5_ResetsBudgetTo0()
        {
            VendingMachine sut = new VendingMachine();

            sut.Budget = 5;

            sut.Refund();

            Assert.AreEqual(0, sut.Budget);
        }
    }

}
