using Abilities.Static;
using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.Promo;

public sealed class ArmoredGroblav : EvolutionCreature
{
    public ArmoredGroblav() : base("Armored Groblav", 5, 6000, Race.Human,
        Civilization.Fire)
    {
        AddStaticAbilities(
            new WhileAttackingThisCreatureGetPowerForEachOtherCreatureInTheBattleZone(
                1000, new CivilizationCreatureFilter(Civilization.Fire)));
        AddAbilities(new DoubleBreakerAbility());
    }
}
