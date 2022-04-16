using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class AerisFlightElemental : Creature
    {
        public AerisFlightElemental() : base("Aeris, Flight Elemental", 5, 9000, Engine.Race.AngelCommand, Engine.Civilization.Light)
        {
            AddThisCreatureCannotAttackPlayersAbility();
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Engine.Civilization.Darkness));
        }
    }
}
