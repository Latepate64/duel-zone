using Common;

namespace Cards.Cards.DM04
{
    class AerisFlightElemental : Creature
    {
        public AerisFlightElemental() : base("Aeris, Flight Elemental", 5, Civilization.Light, 9000, Subtype.AngelCommand)
        {
            Abilities.Add(new StaticAbilities.CannotAttackPlayersAbility());

            // This creature can attack untapped darkness creatures.
            var filter = new CardFilters.OpponentsBattleZoneUntappedCreatureFilter();
            filter.Civilizations.Add(Civilization.Darkness);
            Abilities.Add(new StaticAbilities.CanAttackUntappedCreaturesAbility(filter));
        }
    }
}
