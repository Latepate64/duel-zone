using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;
using CardFilters;

namespace Cards.DM04;

public sealed class BallomMasterOfDeath : EvolutionCreature
{
    public BallomMasterOfDeath() : base("Ballom, Master of Death", 8, 12000,
        Race.DemonCommand, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyAllCreaturesEffect(
                    new NonCivilizationCreatureFilter(Civilization.Darkness)
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}
