using CardFilters;
using ContinuousEffects.CanAttackUntappedCreatures;
using ContinuousEffects.CannotAttackPlayers;
using Interfaces;

namespace Cards.DM04;

sealed class PhotocideLordOfTheWastes : Creature
{
    public PhotocideLordOfTheWastes() : base("Photocide, Lord of the Wastes", 5, 9000,
        Race.DemonCommand, Civilization.Darkness)
    {
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        AddStaticAbilities(
            new ThisCreatureCanAttackUntappedCreaturesEffect(
                new CivilizationCreatureFilter(Civilization.Light)));
    }
}