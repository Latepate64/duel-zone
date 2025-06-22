using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM04;

public class MilieusTheDaystretcher : Creature
{
    public MilieusTheDaystretcher() : base("Milieus, the Daystretcher", 5, 2500, Race.Berserker, Civilization.Light)
    {
        AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        AddStaticAbilities(new EachCivilizationCardCostsMoreEffect(2, Civilization.Darkness));
    }
}
