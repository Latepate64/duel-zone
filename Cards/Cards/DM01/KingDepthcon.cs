using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class KingDepthcon : Creature
    {
        public KingDepthcon() : base("King Depthcon", 7, Common.Civilization.Water, 6000, Common.Subtype.Leviathan)
        {
            Abilities.Add(new DoubleBreakerAbility());
            Abilities.Add(new UnblockableAbility());
        }
    }
}
