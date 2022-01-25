using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class KingDepthcon : Creature
    {
        public KingDepthcon() : base("King Depthcon", 7, Civilization.Water, 6000, Subtype.Leviathan)
        {
            Abilities.Add(new DoubleBreakerAbility());
            Abilities.Add(new UnblockableAbility());
        }
    }
}
