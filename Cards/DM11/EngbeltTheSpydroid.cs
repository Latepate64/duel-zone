using ContinuousEffects;

namespace Cards.DM11
{
    class EngbeltTheSpydroid : Engine.Creature
    {
        public EngbeltTheSpydroid() : base("Engbelt, the Spydroid", 4, 5500, Interfaces.Race.Soltrooper, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
