using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;
using CardFilters;

namespace Cards.DM02;

public sealed class MetalwingSkyterror : Creature
{
    public MetalwingSkyterror() : base("Metalwing Skyterror", 7, 6000,
        Race.ArmoredWyvern, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new BlockerFilter(),
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Graveyard,
                    selectionRange: SelectionRange.OpponentsCards
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}
