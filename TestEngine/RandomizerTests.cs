using System.Collections.Generic;
using Engine;
using Interfaces;
using Moq;
using Xunit;

namespace TestEngine;

public sealed class RandomizerTests
{
    [Fact]
    public void Shuffle()
    {
        // Arrange
        var randomizer = new Randomizer();
        var cards = new List<ICard>
        {
            Mock.Of<ICard>(),
            Mock.Of<ICard>()
        };

        // Act + Assert
        randomizer.Shuffle(cards);
    }
}