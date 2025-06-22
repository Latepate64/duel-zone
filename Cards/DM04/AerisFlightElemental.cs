using ContinuousEffects;

namespace Cards.DM04
{
    sealed class AerisFlightElemental : Engine.Creature
    {
        public AerisFlightElemental() : base("Aeris, Flight Elemental", 5, 9000, Interfaces.Race.AngelCommand, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Interfaces.Civilization.Darkness));
        }
    }
}
