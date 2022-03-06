using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM04
{
    class AerisFlightElemental : Creature
    {
        public AerisFlightElemental() : base("Aeris, Flight Elemental", 5, 9000, Subtype.AngelCommand, Civilization.Light)
        {
            // This creature can attack untapped darkness creatures.
            var filter = new CardFilters.OpponentsBattleZoneUntappedCreatureFilter();
            filter.Civilizations.Add(Civilization.Darkness);
            AddAbilities(new CannotAttackPlayersAbility(), new CanAttackUntappedCreaturesAbility(filter));
        }
    }
}
