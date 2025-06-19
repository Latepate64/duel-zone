using Cards.ContinuousEffects;

namespace Cards.Cards.DM11
{
    class EngbeltTheSpydroid : Engine.Creature
    {
        public EngbeltTheSpydroid() : base("Engbelt, the Spydroid", 4, 5500, Engine.Race.Soltrooper, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
