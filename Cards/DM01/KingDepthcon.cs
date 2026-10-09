using Abilities.Static;
using ContinuousEffects.Unblockable;

namespace Cards.DM01
{
    sealed class KingDepthcon : Creature
    {
        public KingDepthcon() : base("King Depthcon", 7, 6000, Interfaces.Race.Leviathan, Interfaces.Civilization.Water)
        {
            AddAbilities(new DoubleBreakerAbility());
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
