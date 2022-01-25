using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    public class HanusaRadianceElemental : Creature
    {
        public HanusaRadianceElemental() : base("Hanusa, Radiance Elemental", 7, Civilization.Light, 9500, Subtype.AngelCommand)
        {
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
