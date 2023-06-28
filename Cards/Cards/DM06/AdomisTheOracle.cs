using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM06
{
    class AdomisTheOracle : Creature
    {
        public AdomisTheOracle() : base("Adomis, the Oracle", 3, 2000, Race.LightBringer, Civilization.Light)
        {
            AddTapAbility(new AdomisTheOracleEffect());
        }
    }

    class AdomisTheOracleEffect : CardSelectionEffect
    {
        public AdomisTheOracleEffect() : base(1, 1, true)
        {
        }

        public AdomisTheOracleEffect(AdomisTheOracleEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new AdomisTheOracleEffect();
        }

        public override string ToString()
        {
            return "Choose a shield and look at it. Then put it back where it was.";
        }

        protected override void Apply(IAbility source, params ICard[] cards)
        {
            Applier.Look(Applier.Opponent, cards);
            Applier.Opponent.Unreveal(cards);
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Game.Players.SelectMany(x => x.ShieldZone.Cards);
        }
    }
}
