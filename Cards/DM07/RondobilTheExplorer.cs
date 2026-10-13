using Abilities;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class RondobilTheExplorer : Creature
{
    public RondobilTheExplorer() : base("Rondobil, the Explorer", 6, 5000,
        Race.Gladiator, Civilization.Light)
    {
        AddAbilities(
            new TapAbility(
                new CardMovingChoiceEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    source: ZoneType.BattleZone,
                    destination: ZoneType.ShieldZone,
                    selectionRange: SelectionRange.OwnCreatures
                )));
    }
}
