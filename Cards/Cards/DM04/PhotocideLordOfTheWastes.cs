using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM04
{
    class PhotocideLordOfTheWastes : Creature
    {
        public PhotocideLordOfTheWastes() : base("Photocide, Lord of the Wastes", 5, 9000, Subtype.DemonCommand, Civilization.Darkness)
        {
            // This creature can attack untapped light creatures.
            AddAbilities(new CannotAttackPlayersAbility(), new CanAttackUntappedCreaturesAbility(new CardFilters.OpponentsBattleZoneUntappedCivilizationCreatureFilter(Civilization.Light)));
        }
    }
}
