using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using Interfaces.Zones;

namespace Cards.DM06;

public sealed class ArmoredScoutGestuchar : Creature
{
    public ArmoredScoutGestuchar(
        PowerAttackerAbilityFactory powerAttackerAbilityFactory,
        IBattleZone battleZone
    ) : base("Armored Scout Gestuchar", 5, 4000,
        Race.Armorloid, Civilization.Fire)
    {
        AddStaticAbilities(
            new ThisCreatureHasAbilitiesEffect(
                new ControllerControlsNoOtherCreaturesCondition(
                    battleZone,
                    new CivilizationCreatureFilter(Civilization.Fire)),
                powerAttackerAbilityFactory.Create(3000),
                new DoubleBreakerAbility()
        ));
    }
}
