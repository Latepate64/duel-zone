using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

sealed class ÜberdragonBajula : DragonEvolutionCreature
{
    public ÜberdragonBajula() : base("Überdragon Bajula", 7, 13000,
        Race.ArmoredDragon, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 2,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    source: ZoneType.ManaZone,
                    destination: ZoneType.Graveyard,
                    selectionRange: SelectionRange.OpponentsCreatures
        )));
    }
}