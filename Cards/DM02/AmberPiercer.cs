using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

sealed class AmberPiercer : Creature
{
    public AmberPiercer() : base("Amber Piercer", 4, 2000, Race.BrainJacker,
        Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    source: ZoneType.Graveyard,
                    destination: ZoneType.Hand,
                    selectionRange: SelectionRange.OwnCreatures
        )));
    }
}