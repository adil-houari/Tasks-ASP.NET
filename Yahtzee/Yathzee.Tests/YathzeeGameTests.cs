using Yahtzee;

namespace Yathzee.Tests

{

    // AAA METHODE (zie powerpoint) // Arrange // Act // Assert
    // sut gebruiken als naam
    // naamgeveving (zie les 5 powerpoint)
    // Constructor niet globaal maken, in de test zelf creeren
    // global using FluentAssertions; && global using NSubstitute; toevoegen in GlobalUsing
    // zie demo les 5 + les 4 (update) voor Substitute
    // zie demo + powerpoint voor Random -----> RandomProvider



    public class YathzeeGameTests
    {

        // TEST ones
        [Fact]
        public void CalculateYahtzeeValue_OnesCategory_ZeroScore()
        {
            // Arrange
            IRandomProvider randomProvider = Substitute.For<IRandomProvider>();
            randomProvider.Next(1, 7).Returns(5, 6, 4); 

            YahtzeeGame sut = new YahtzeeGame(randomProvider);

            // Act
            sut.RollAllDice(); 
            var score = sut.CalculateYahtzeeValue(YahtzeeCategory.Ones);

            // Assert
            Assert.Equal(0, score);
        }


        [Fact]
        public void CalculateYahtzeeValue_OnesCategory_NonZeroScore()
        {
            // Arrange
            IRandomProvider randomProvider = Substitute.For<IRandomProvider>();
            randomProvider.Next(1, 7).Returns(1, 1, 3, 4, 1);

            YahtzeeGame sut = new YahtzeeGame(randomProvider);

            // Act
            sut.RollAllDice(); 
            var score = sut.CalculateYahtzeeValue(YahtzeeCategory.Ones);

            // Assert
            Assert.Equal(3, score); 
        }


        // TEST LargeStraight
        [Fact]
        public void CalculateYahtzeeValue_LargeStraightCategory_ZeroScore()
        {
            // Arrange
            IRandomProvider randomProvider = Substitute.For<IRandomProvider>();
            randomProvider.Next(1, 7).Returns(1, 2, 3, 4, 5);

            YahtzeeGame sut = new YahtzeeGame(randomProvider);

            // Act
            sut.RollAllDice();
            var score = sut.CalculateYahtzeeValue(YahtzeeCategory.LargeStraight);

            // Assert
            Assert.Equal(0, score);
        }

        [Fact]
        public void CalculateYahtzeeValue_LargeStraightCategory_NonZeroScore()
        {
            // Arrange
            IRandomProvider randomProvider = Substitute.For<IRandomProvider>();
            randomProvider.Next(1, 7).Returns(2, 3, 4, 5, 6);

            YahtzeeGame sut = new YahtzeeGame(randomProvider);

            // Act
            sut.RollAllDice(); 
            var score = sut.CalculateYahtzeeValue(YahtzeeCategory.LargeStraight);

            // Assert
            Assert.Equal(40, score);
        }



        // TEST Category
        [Fact]
        public void CalculateYahtzeeValue_YahtzeeCategory_ZeroScore()
        {
            // Arrange
            IRandomProvider randomProvider = Substitute.For<IRandomProvider>();
            randomProvider.Next(1, 7).Returns(1, 2, 3, 4, 6);

            YahtzeeGame sut = new YahtzeeGame(randomProvider);

            // Act
            sut.RollAllDice(); 
            var score = sut.CalculateYahtzeeValue(YahtzeeCategory.Yahtzee);

            // Assert
            Assert.Equal(0, score);
        }

        [Fact]
        public void CalculateYahtzeeValue_YahtzeeCategory_NonZeroScore()
        {
            // Arrange
            IRandomProvider randomProvider = Substitute.For<IRandomProvider>();
            randomProvider.Next(1, 7).Returns(3, 3, 3, 3, 3);

            YahtzeeGame sut = new YahtzeeGame(randomProvider);

            // Act
            sut.RollAllDice(); 
            var score = sut.CalculateYahtzeeValue(YahtzeeCategory.Yahtzee);

            // Assert
            Assert.Equal(50, score); 
        }
    }
}