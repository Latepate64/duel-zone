using Abilities;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class AquaFencer : Creature
{
    public AquaFencer() : base("Aqua Fencer", 7, 3000, Race.LiquidPeople,
        Civilization.Water)
    {
        AddAbilities(
            new TapAbility(
                new ManaRecoveryEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    ownMana: false
        )));
    }
}