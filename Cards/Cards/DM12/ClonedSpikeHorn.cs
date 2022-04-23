using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM12
{
    class ClonedSpikeHorn : Creature
    {
        public ClonedSpikeHorn() : base("Cloned Spike-Horn", 4, 3000, Race.HornedBeast, Civilization.Nature)
        {
            AddStaticAbilities(new ClonedSpikeHornEffect(), new ContinuousEffects.PoweredDoubleBreaker());
        }
    }

    class ClonedSpikeHornEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public ClonedSpikeHornEffect(int power = 3000) : base(power)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ClonedSpikeHornEffect();
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power for each Cloned Spike-Horn in each graveyard.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.Players.SelectMany(x => x.Graveyard.Cards).Count(x => x.Name == "Cloned Spike-Horn");
        }
    }
}
