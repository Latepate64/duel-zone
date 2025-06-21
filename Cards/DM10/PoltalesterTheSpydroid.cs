using ContinuousEffects;

namespace Cards.DM10
{
    class PoltalesterTheSpydroid : Engine.Creature
    {
        public PoltalesterTheSpydroid() : base("Poltalester, the Spydroid", 5, 2000, Interfaces.Race.Soltrooper, Interfaces.Civilization.Light)
        {
            AddShieldTrigger();
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
