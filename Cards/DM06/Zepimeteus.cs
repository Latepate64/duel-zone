using ContinuousEffects;

namespace Cards.DM06
{
    class Zepimeteus : Engine.Creature
    {
        public Zepimeteus() : base("Zepimeteus", 1, 2000, Interfaces.Race.SeaHacker, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
