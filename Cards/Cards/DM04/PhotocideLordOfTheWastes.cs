using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM04
{
    class PhotocideLordOfTheWastes : Creature
    {
        public PhotocideLordOfTheWastes() : base("Photocide, Lord of the Wastes", 5, 9000, Subtype.DemonCommand, Civilization.Darkness)
        {
            AddThisCreatureCannotAttackPlayersAbility();
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Civilization.Light));
        }
    }
}
