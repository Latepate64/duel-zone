using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Moq;

namespace TestEngine
{
    public class CardTests
    {
        //[Theory]
        //[InlineData(true)]
        //[InlineData(false)]
        //void CanEvolveFrom_ShouldBeAbleToEvolve_ReturnTrue(bool shouldBeAbleToEvolve)
        //{
        //    Assert.Equal(
        //        shouldBeAbleToEvolve,
        //        new CardMock().CanEvolveFrom(
        //            new GameMock(shouldBeAbleToEvolve).Object,
        //            new CardMock()));
        //}
    }

    class CardMock : Card
    {
        public override ICard Copy()
        {
            throw new System.NotImplementedException();
        }
    }

    class GameMock : Mock<IGame>
    {
        public GameMock(bool shouldBeAbleToEvolve)
        {
            //Setup(x => x.GetContinuousEffects<IEvolutionEffect>()).Returns(new List<IEvolutionEffect> { new EvolutionEffectMock(shouldBeAbleToEvolve) });
        }
    }

    class EvolutionEffectMock : IEvolutionEffect
    {
        public System.Guid SourceAbility { get; set; }
        public int Timestamp { get; set; }
        public IPlayer Applier { get; set; }
        public IAbility Ability { get; set; }
        public ICard Source { get; }
        public IGame Game { get; }

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

        public bool CanEvolve(IGame game, ICard evolutionCreature)
        {
            throw new System.NotImplementedException();
        }

        public void Evolve(ICard evolutionCreature, IGame game)
        {
            throw new System.NotImplementedException();
        }
    }
}
