using Engine;
using Engine.ContinuousEffects;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace TestEngine
{
    public class CardTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        void CanEvolveFrom_ShouldBeAbleToEvolve_ReturnTrue(bool shouldBeAbleToEvolve)
        {
            var card = new Card();
            var game = new Mock<IGame>();
            var bait = new Mock<ICard>();
            var evolutionEffect = new Mock<IEvolutionEffect>();
            evolutionEffect.Setup(x => x.CanEvolveFrom(bait.Object, card, game.Object)).Returns(shouldBeAbleToEvolve);
            game.Setup(x => x.GetContinuousEffects<IEvolutionEffect>()).Returns(new List<IEvolutionEffect> { evolutionEffect.Object });

            var canEvolve = card.CanEvolveFrom(game.Object, bait.Object);

            Assert.Equal(shouldBeAbleToEvolve, canEvolve);
        }
    }
}
