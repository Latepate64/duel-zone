using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06;

sealed class CrazeValkyrieTheDrastic : EvolutionCreature
{
    public CrazeValkyrieTheDrastic() : base("Craze Valkyrie, the Drastic", 6,
        7500, Race.Initiate, Civilization.Light)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new TapChoiceEffect(
                    minimum: 0,
                    maximum: 2,
                    ownerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}