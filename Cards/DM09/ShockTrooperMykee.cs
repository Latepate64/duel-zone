using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09;

sealed class ShockTrooperMykee : Creature
{
    public ShockTrooperMykee() : base("Shock Trooper Mykee", 6, 1000,
        Race.Human, Civilization.Fire)
    {
        AddAbilities(new SpeedAttackerAbility());
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new DestroyEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MaxPowerFilter(3000),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}