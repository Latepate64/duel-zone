using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;
using CardFilters;

namespace Cards.DM01;

public sealed class Gigaberos : Creature
{
    public Gigaberos() : base("Gigaberos", 5, 8000, Race.Chimera, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyTwoOfYourOtherCreatureOrThisCreatureEffect(
                    new CreatureFilter()
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}
