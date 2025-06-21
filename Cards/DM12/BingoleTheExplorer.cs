using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM12
{
    class BingoleTheExplorer : Creature
    {
        public BingoleTheExplorer() : base("Bingole, the Explorer", 4, 3000, Race.Gladiator, Civilization.Light)
        {
            AddStaticAbilities(new OptionalMadnessEffect());
        }
    }
}
