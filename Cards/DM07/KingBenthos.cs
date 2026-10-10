using Abilities;
using Abilities.Static;
using CardFilters;
using ContinuousEffects.Unblockable;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

public sealed class KingBenthos : Creature
{
    public KingBenthos() : base("King Benthos", 8, 6000, Race.Leviathan,
        Civilization.Water)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddAbilities(
            new TapAbility(
                new EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(
                    new StaticAbility(new ThisCreatureCannotBeBlockedEffect()),
                    new CivilizationCreatureFilter(Civilization.Water)
                )));
    }
}
