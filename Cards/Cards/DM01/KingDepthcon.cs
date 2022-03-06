using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class KingDepthcon : Creature
    {
        public KingDepthcon() : base("King Depthcon", 7, 6000, Common.Subtype.Leviathan, Common.Civilization.Water)
        {
            AddAbilities(new DoubleBreakerAbility());
            AddAbilities(new UnblockableAbility());
        }
    }
}
