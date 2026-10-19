using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM04;

sealed class ExplodingCactus : Creature
{
    public ExplodingCactus() : base("Exploding Cactus", 3, 2000, Race.TreeFolk, Civilization.Nature)
    {
        AddStaticAbilities(
            new WhileYouControlAtLeastOneCreatureThisCreatureGetsPowerEffect(
                2000,
                new CivilizationCreatureFilter(Civilization.Light)));
    }
}