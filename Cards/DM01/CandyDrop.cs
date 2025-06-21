using ContinuousEffects;

namespace Cards.DM01
{
    class CandyDrop : Engine.Creature
    {
        public CandyDrop() : base("Candy Drop", 3, 1000, Engine.Race.CyberVirus, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
