using CardFilters;
using ContinuousEffects.CanAttackUntappedCreatures;
using ContinuousEffects.CannotAttackPlayers;
using Interfaces;

namespace Cards.DM04;

sealed class AerisFlightElemental : Creature
{
    public AerisFlightElemental() : base("Aeris, Flight Elemental", 5, 9000, Race.AngelCommand,
        Civilization.Light)
    {
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        AddStaticAbilities(
            new ThisCreatureCanAttackUntappedCreaturesEffect(
                new CivilizationCreatureFilter(Civilization.Darkness)));
    }
}