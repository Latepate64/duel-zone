using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class HanusaRadianceElemental : Creature
    {
        public HanusaRadianceElemental() : base("Hanusa, Radiance Elemental", 7, Common.Civilization.Light, 9500, Common.Subtype.AngelCommand)
        {
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
