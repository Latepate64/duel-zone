using Cards.ContinuousEffects;
using ContinuousEffects;

namespace Cards.Cards.DM10
{
    class PoltalesterTheSpydroid : Engine.Creature
    {
        public PoltalesterTheSpydroid() : base("Poltalester, the Spydroid", 5, 2000, Engine.Race.Soltrooper, Engine.Civilization.Light)
        {
            AddShieldTrigger();
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
