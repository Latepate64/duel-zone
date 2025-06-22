using ContinuousEffects;

namespace Cards.DM04
{
    sealed class PhotocideLordOfTheWastes : Engine.Creature
    {
        public PhotocideLordOfTheWastes() : base("Photocide, Lord of the Wastes", 5, 9000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Interfaces.Civilization.Light));
        }
    }
}
