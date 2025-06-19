using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM08
{
    class ProwlingElephish : Engine.Creature
    {
        public ProwlingElephish() : base("Prowling Elephish", 4, 2000, Engine.Race.GelFish, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
