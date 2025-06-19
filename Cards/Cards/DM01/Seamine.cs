using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class Seamine : Engine.Creature
    {
        public Seamine() : base("Seamine", 6, 4000, Engine.Race.Fish, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
