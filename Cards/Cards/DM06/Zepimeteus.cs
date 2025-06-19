using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class Zepimeteus : Engine.Creature
    {
        public Zepimeteus() : base("Zepimeteus", 1, 2000, Engine.Race.SeaHacker, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
