using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class DiaNorkMoonlightGuardian : Creature
    {
        public DiaNorkMoonlightGuardian() : base("Dia Nork, Moonlight Guardian", 4, 5000, Engine.Race.Guardian, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
