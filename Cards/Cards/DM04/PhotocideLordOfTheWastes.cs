using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class PhotocideLordOfTheWastes : Creature
    {
        public PhotocideLordOfTheWastes() : base("Photocide, Lord of the Wastes", 5, 9000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddThisCreatureCannotAttackPlayersAbility();
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Engine.Civilization.Light));
        }
    }
}
