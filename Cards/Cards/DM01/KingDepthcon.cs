using Cards.ContinuousEffects;
using ContinuousEffects;

namespace Cards.Cards.DM01
{
    class KingDepthcon : Engine.Creature
    {
        public KingDepthcon() : base("King Depthcon", 7, 6000, Engine.Race.Leviathan, Engine.Civilization.Water)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
