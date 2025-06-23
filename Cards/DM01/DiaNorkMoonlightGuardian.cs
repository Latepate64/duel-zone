using ContinuousEffects;

namespace Cards.DM01
{
    sealed class DiaNorkMoonlightGuardian : Creature
    {
        public DiaNorkMoonlightGuardian() : base("Dia Nork, Moonlight Guardian", 4, 5000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
