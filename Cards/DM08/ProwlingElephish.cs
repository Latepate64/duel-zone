using ContinuousEffects;

namespace Cards.DM08
{
    class ProwlingElephish : Engine.Creature
    {
        public ProwlingElephish() : base("Prowling Elephish", 4, 2000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
