using CardFilters;
using ContinuousEffects.CanAttackUntappedCreatures;
using ContinuousEffects.CannotAttackPlayers;
using Interfaces;

namespace Cards.DM05;

sealed class RuthlessSkyterror : Creature
{
    public RuthlessSkyterror() : base("Ruthless Skyterror", 4, 6000, Race.ArmoredWyvern,
        Civilization.Fire)
    {
        AddStaticAbilities(
            new ThisCreatureCanAttackUntappedCreaturesEffect(
                new CivilizationCreatureFilter(Civilization.Water)));
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
    }
}