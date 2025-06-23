using ContinuousEffects;

namespace Cards.DM01
{
    sealed class KingDepthcon : Creature
    {
        public KingDepthcon() : base("King Depthcon", 7, 6000, Interfaces.Race.Leviathan, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
