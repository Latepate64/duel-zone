using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM02;

sealed class LeapingTornadoHorn : Creature
{
    public LeapingTornadoHorn() : base("Leaping Tornado Horn", 3, 2000,
        Race.HornedBeast, Civilization.Nature)
    {
        AddStaticAbilities(
            new WhileAttackingGetPowerForEachOfYourOtherCreaturesEffect(
                1000, new CreatureFilter()));
    }
}