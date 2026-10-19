using StaticAbilities;
using ContinuousEffects.Unblockable;
using Interfaces;
using CardFilters;

namespace Cards.DM02;

public sealed class KingNautilus : Creature
{
    public KingNautilus() : base("King Nautilus", 8, 6000, Race.Leviathan, Civilization.Water)
    {
        AddStaticAbilities(
            new CreaturesCannotBeBlockedEffect(
                attackerFilter: new RaceCreatureFilter(Race.LiquidPeople),
                blockerFilter: new CreatureFilter()));
        AddAbilities(new DoubleBreakerAbility());
    }
}
