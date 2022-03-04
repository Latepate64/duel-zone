using Common;

namespace Cards.Cards.DM04
{
    class PhotocideLordOfTheWastes : Creature
    {
        public PhotocideLordOfTheWastes() : base("Photocide, Lord of the Wastes", 5, Civilization.Darkness, 9000, Subtype.DemonCommand)
        {
            Abilities.Add(new StaticAbilities.CannotAttackPlayersAbility());

            // This creature can attack untapped light creatures.
            var filter = new CardFilters.OpponentsBattleZoneUntappedCreatureFilter();
            filter.Civilizations.Add(Civilization.Light);
            Abilities.Add(new StaticAbilities.CanAttackUntappedCreaturesAbility(filter));
        }
    }
}
