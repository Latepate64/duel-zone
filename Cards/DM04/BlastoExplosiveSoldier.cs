using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM04;

sealed class BlastoExplosiveSoldier : Creature
{
    public BlastoExplosiveSoldier() : base("Blasto, Explosive Soldier", 3, 2000, Race.Dragonoid,
        Civilization.Fire)
    {
        AddStaticAbilities(
            new WhileYouControlAtLeastOneCreatureThisCreatureGetsPowerEffect(
                2000,
                new CivilizationCreatureFilter(Civilization.Darkness)));
    }
}