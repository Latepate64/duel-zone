using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM12
{
    class ClonedSpikeHorn : Creature
    {
        public ClonedSpikeHorn() : base("Cloned Spike-Horn", 4, 3000, Engine.Subtype.HornedBeast, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ClonedSpikeHornEffect(), new ContinuousEffects.PoweredDoubleBreaker());
        }
    }

    class ClonedSpikeHornEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public ClonedSpikeHornEffect() : base(3000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ClonedSpikeHornEffect();
        }

        public override string ToString()
        {
            return "This creature gets +3000 power for each Cloned Spike-Horn in each graveyard.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.Players.SelectMany(x => x.Graveyard.Cards).Count(x => x.Name == "Cloned Spike-Horn");
        }
    }
}
