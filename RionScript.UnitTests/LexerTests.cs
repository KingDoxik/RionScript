using System;
using Xunit;
using RionScript;
using System.Linq;

namespace RionScript.UnitTests
{
    public class LexerTests
    {
        [Theory]
        [InlineData("3 + 4", 3)]
        [InlineData("3 + 4 + 2", 5)]
        [InlineData("3 + (4 - 1)", 7)]
        public void GenerateNumber_TestLexerOutputsCorrectNumberOfEvalTokens(string evalString, int expectedNumberOfTokens)
        {
            // Arrange
            var lexer = new Lexer(evalString);
            // Act
            var numberOftokens = lexer.GenerateTokens().Count();
            // Assert
            Assert.Equal(expectedNumberOfTokens, numberOftokens);
        }
    }
}
