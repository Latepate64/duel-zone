using Cards.CardFilters;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class KingNautilus : Creature
    {
        public KingNautilus() : base("King Nautilus", 8, 6000, Subtype.Leviathan, Civilization.Water)
        {
            AddAbilities(new KingNautilusAbility(), new StaticAbilities.DoubleBreakerAbility());
        }
    }

    class KingNautilusAbility : StaticAbility
    {
        public KingNautilusAbility() : base(new KingNautilusEffect())
        {
        }
    }

    class KingNautilusEffect : Engine.ContinuousEffects.UnblockableEffect
    {
        public KingNautilusEffect() : base(new BattleZoneSubtypeCreatureFilter(Subtype.LiquidPeople), new BattleZoneCreatureFilter())
        {
        }

        public override string ToString()
        {
            return "Liquid People can't be blocked.";
        }
    }
}
