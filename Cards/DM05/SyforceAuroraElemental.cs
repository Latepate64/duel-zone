using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM05;

sealed class SyforceAuroraElemental : Creature
{
    public SyforceAuroraElemental() : base("Syforce, Aurora Elemental", 7, 7000,
        Race.AngelCommand, Civilization.Light)
    {
        AddAbilities(new BlockerAbility());
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ManaRecoveryEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new SpellFilter(),
                    selectionRange: SelectionRange.OwnCreatures
        )));
        AddAbilities(new DoubleBreakerAbility());
    }
}