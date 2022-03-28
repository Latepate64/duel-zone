using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM04
{
    class AerisFlightElemental : Creature
    {
        public AerisFlightElemental() : base("Aeris, Flight Elemental", 5, 9000, Subtype.AngelCommand, Civilization.Light)
        {
            AddThisCreatureCannotAttackPlayersAbility();
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Civilization.Darkness));
        }
    }
}
