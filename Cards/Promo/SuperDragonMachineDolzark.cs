using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.Promo;

public sealed class SuperDragonMachineDolzark : Creature
{
    public SuperDragonMachineDolzark() : base("Super Dragon Machine Dolzark", 6,
        7000, [Race.ArmoredDragon, Race.EarthDragon], Civilization.Fire,
        Civilization.Nature)
    {
        AddTriggeredAbility(
            new DolzarkAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MaxPowerFilter(5000),
                    source: ZoneType.BattleZone,
                    destination: ZoneType.ManaZone,
                    selectionRange: SelectionRange.OpponentsCards
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}
