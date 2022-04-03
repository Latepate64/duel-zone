using Cards.CardFilters;
using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM11
{
    class SpinningTerrorTheWretched : Creature
    {
        public SpinningTerrorTheWretched() : base("Spinning Terror, the Wretched", 2, 1000, Subtype.DevilMask, Civilization.Darkness)
        {
            AddStaticAbilities(new SpinningTerrorTheWretchedEffect());
        }
    }

    class SpinningTerrorTheWretchedEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public SpinningTerrorTheWretchedEffect() : base(2000, new OpponentsBattleZoneTappedCreatureFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new SpinningTerrorTheWretchedEffect();
        }

        public override string ToString()
        {
            return "This creature gets +2000 power for each tapped creature your opponent has in the battle zone.";
        }
    }

    class OpponentsBattleZoneTappedCreatureFilter : OpponentsBattleZoneCreatureFilter
    {
        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && card.Tapped;
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneTappedCreatureFilter();
        }
    }
}
