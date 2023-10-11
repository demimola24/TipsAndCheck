using Xunit;
using TipsAndChequesLibrary;

namespace TipsAndChequesaTests
{
    
public class TipsAndChequesaTests
{
     private readonly TipsAndCheques _tipsAndCheques = new TipsAndCheques();

        [Theory]
        [InlineData(100, 4, 25)]
        [InlineData(50, 2, 25)]
        [InlineData(200, 5, 40)]

        public void CalculateSplitAmount_ShouldReturnCorrectAmount(decimal amount, int numberOfPeople, decimal expectedResult)
        {
            var result = _tipsAndCheques.CalculateSplitAmount(amount, numberOfPeople);
            Assert.Equal(expectedResult, result);
        }



        [Fact]
        public void CalculateTipAmount_ShouldReturnCorrectTip()
        {
            var tipsAndCheques = new TipsAndCheques();
            var cost = new Dictionary<string, decimal>
            {
                { "Alice", 50m },
                { "Bob", 30m },
                { "Charlie", 20m }
            };
            var tipPercentage = 20f;
            var expectedTips = new Dictionary<string, decimal>
            {
                { "Alice", 10m },
                { "Bob", 6m },
                { "Charlie", 4m }
            };
            var actualTips = tipsAndCheques.CalculateTipAmount(cost, tipPercentage);
            Assert.Equal(expectedTips, actualTips);
        }

        [Fact]
        public void CalculateTip_ShouldHandleEmptyDictionary()
        {
            var tipsAndCheques = new TipsAndCheques();
            var actualTips = tipsAndCheques.CalculateTipAmount(new Dictionary<string, decimal>(), 20f);
            Assert.Empty(actualTips);
        }

        [Fact]
        public void CalculateTip_ShouldReturnArgumentExceptionForNegativeTipPercentage()
        {
            var tipsAndCheques = new TipsAndCheques();
            Assert.Throws<ArgumentException>(() => tipsAndCheques.CalculateTipAmount(new Dictionary<string, decimal>(), -10f));
        }

        [Theory]
        [InlineData(100, 4, 20, 5)]
        [InlineData(200, 5, 15, 6)]
        [InlineData(150, 3, 10, 5)]
        public void CalculateIndividualTip_ShouldReturnCorrectAmount(decimal totalAmount, int numberOfPatrons, float tipPercentage, decimal expectedTipPerPerson)
        {
            var tipsAndCheques = new TipsAndCheques();
            decimal actualTipPerPerson = tipsAndCheques.CalculateIndividualTip(totalAmount, numberOfPatrons, tipPercentage);
            Assert.Equal(expectedTipPerPerson, actualTipPerPerson);
        }
}
}
