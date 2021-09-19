﻿using DuelMastersModels;
using DuelMastersModels.Zones;
using Moq;
using System;
using Xunit;

namespace UnitTests
{
    public class PlayerTests
    {
        [Fact]
        public void ShuffleDeck_DeckNull_ThrowNullReferenceException()
        {
            _ = Assert.Throws<NullReferenceException>(() => new Player().ShuffleDeck());
        }

        [Fact]
        public void ShuffleDeck_DeckNotNull_ShuffleCalledOnce()
        {
            Mock<Deck> deck = new Mock<Deck>();
            new Player { Deck = deck.Object }.ShuffleDeck();
            deck.Verify(x => x.Shuffle(), Times.Once);
        }
    }
}
