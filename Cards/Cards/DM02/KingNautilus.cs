using Cards.CardFilters;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class KingNautilus : Creature
    {
        public KingNautilus() : base("King Nautilus", 8, 6000, Subtype.Leviathan, Civilization.Water)
        {
            AddAbilities(new StaticAbility(new Engine.ContinuousEffects.UnblockableEffect(new BattleZoneSubtypeCreatureFilter(Subtype.LiquidPeople), new BattleZoneCreatureFilter())), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
