using Abilities.Static;
using ContinuousEffects.CostModifying;
using Interfaces;

namespace Cards.DM04;

public sealed class MilieusTheDaystretcher : Creature
{
    public MilieusTheDaystretcher() : base("Milieus, the Daystretcher", 5, 2500, Race.Berserker, Civilization.Light)
    {
        AddAbilities(new BlockerAbility());
        AddStaticAbilities(new EachCivilizationCardCostsMoreEffect(2, Civilization.Darkness));
    }
}
