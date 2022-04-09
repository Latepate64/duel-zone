using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM12
{
    class ClonedSpikeHorn : Creature
    {
        public ClonedSpikeHorn() : base("Cloned Spike-Horn", 4, 3000, Subtype.HornedBeast, Civilization.Nature)
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

    class ClonedSpikeHornFilter : CardFilter
    {
        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return card.Name == "Cloned Spike-Horn" && game.Players.SelectMany(x => x.Graveyard.Cards).Contains(card);
        }

        public override ICardFilter Copy()
        {
            return new ClonedSpikeHornFilter();
        }
    }
}
