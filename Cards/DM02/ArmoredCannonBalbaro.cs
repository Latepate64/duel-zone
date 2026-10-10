using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM02;

public sealed class ArmoredCannonBalbaro : EvolutionCreature
{
    public ArmoredCannonBalbaro() : base("Armored Cannon Balbaro", 3, 3000,
        Race.Human, Civilization.Fire)
    {
        AddStaticAbilities(
            new WhileAttackingThisCreatureGetPowerForEachOtherCreatureInTheBattleZone(
                2000, new RaceCreatureFilter(Race.Human)));
    }
}
