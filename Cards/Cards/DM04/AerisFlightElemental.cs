using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM04
{
    class AerisFlightElemental : Creature
    {
        public AerisFlightElemental() : base("Aeris, Flight Elemental", 5, 9000, Subtype.AngelCommand, Civilization.Light)
        {
            AddAbilities(new ThisCreatureCannotAttackPlayersAbility(), new ThisCreatureCanAttackUntappedCivilizationCreaturesAbility(Civilization.Darkness));
        }
    }
}
