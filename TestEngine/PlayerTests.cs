using Engine;
using Engine.ContinuousEffects;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace TestEngine
{
    public class PlayerTests
    {
        [Fact]
        public void Evolve_EvolutionCreatureHasEvolutionEffect_Pass()
        {
            var evolutionCreature = new Mock<ICard>();
            evolutionCreature.Setup(x => x.GetEvolutionEffects()).Returns(new List<IEvolutionEffect> { Mock.Of<IEvolutionEffect>() });

            new PlayerMock().Evolve(evolutionCreature.Object, Mock.Of<IGame>());
        }
    }
}
