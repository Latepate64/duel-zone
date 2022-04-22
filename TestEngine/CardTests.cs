using Engine;
using Engine.Abilities;
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
            Assert.Equal(
                shouldBeAbleToEvolve,
                new Card().CanEvolveFrom(
                    new GameMock(shouldBeAbleToEvolve).Object,
                    new Card()));
        }
    }

    class GameMock : Mock<IGame>
    {
        public GameMock(bool shouldBeAbleToEvolve)
        {
            Setup(x => x.GetContinuousEffects<IEvolutionEffect>()).Returns(new List<IEvolutionEffect> { new EvolutionEffectMock(shouldBeAbleToEvolve) });
        }
    }

    class EvolutionEffectMock : IEvolutionEffect
    {
        public System.Guid SourceAbility { get; set; }
        public int Timestamp { get; set; }
        public IPlayer Controller { get; set; }
        public IAbility Ability { get; set; }
        public ICard Source { get; }

        private readonly bool _shouldBeAbleToEvolve;

        public EvolutionEffectMock(bool shouldBeAbleToEvolve)
        {
            _shouldBeAbleToEvolve = shouldBeAbleToEvolve;
        }

        public bool CanEvolveFrom(ICard bait, ICard evolutionCard, IGame game)
        {
            return _shouldBeAbleToEvolve;
        }

        public IContinuousEffect Copy()
        {
            throw new System.NotImplementedException();
        }
    }
}
