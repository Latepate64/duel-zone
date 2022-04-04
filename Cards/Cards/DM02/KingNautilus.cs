using Cards.CardFilters;
using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class KingNautilus : Creature
    {
        public KingNautilus() : base("King Nautilus", 8, 6000, Subtype.Leviathan, Civilization.Water)
        {
            AddStaticAbilities(new KingNautilusEffect());
            AddDoubleBreakerAbility();
        }
    }

    class KingNautilusEffect : ContinuousEffects.UnblockableEffect
    {
        public KingNautilusEffect() : base(new BattleZoneSubtypeCreatureFilter(Subtype.LiquidPeople), new Durations.Indefinite(), new BattleZoneCreatureFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new KingNautilusEffect();
        }

        public override string ToString()
        {
            return "Liquid People can't be blocked.";
        }
    }
}
