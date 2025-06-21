using ContinuousEffects;

namespace Cards.DM04
{
    class AerisFlightElemental : Engine.Creature
    {
        public AerisFlightElemental() : base("Aeris, Flight Elemental", 5, 9000, Engine.Race.AngelCommand, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Engine.Civilization.Darkness));
        }
    }
}
