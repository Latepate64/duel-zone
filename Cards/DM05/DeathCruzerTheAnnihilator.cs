using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;
using CardFilters;

namespace Cards.DM05;

public sealed class DeathCruzerTheAnnihilator : Creature
{
    public DeathCruzerTheAnnihilator() : base("Death Cruzer, the Annihilator",
        7, 13000, Race.DemonCommand, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyAllYourOtherCreaturesEffect(
                    new CreatureFilter()
                )));
        AddAbilities(new TripleBreakerAbility());
    }
}