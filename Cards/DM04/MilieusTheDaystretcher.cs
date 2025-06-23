using ContinuousEffects;
using Interfaces;

namespace Cards.DM04;

public sealed class MilieusTheDaystretcher : Creature
{
    public MilieusTheDaystretcher() : base("Milieus, the Daystretcher", 5, 2500, Race.Berserker, Civilization.Light)
    {
        AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        AddStaticAbilities(new EachCivilizationCardCostsMoreEffect(2, Civilization.Darkness));
    }
}
