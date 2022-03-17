using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM04
{
    class AerisFlightElemental : Creature
    {
        public AerisFlightElemental() : base("Aeris, Flight Elemental", 5, 9000, Subtype.AngelCommand, Civilization.Light)
        {
            // This creature can attack untapped darkness creatures.
            AddAbilities(new CannotAttackPlayersAbility(), new CanAttackUntappedCreaturesAbility(new CardFilters.OpponentsBattleZoneUntappedCivilizationCreatureFilter(Civilization.Darkness)));
        }
    }
}
