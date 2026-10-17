using Abilities.Static;
using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM08;

public sealed class SashaChannelerOfSuns : Creature
{
    public SashaChannelerOfSuns(DragonFilterFactory dragonFilterFactory)
    : base("Sasha, Channeler of Suns", 8, 9500, Race.MechaDelSol, Civilization.Light)
    {
        AddAbilities(new BlockerAbility(dragonFilterFactory.Create()));
        AddStaticAbilities(new SashaPowerEffect());
        AddAbilities(new DoubleBreakerAbility());
    }
}
