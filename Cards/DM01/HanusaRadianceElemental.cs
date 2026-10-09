using Abilities.Static;

namespace Cards.DM01
{
    sealed class HanusaRadianceElemental : Creature
    {
        public HanusaRadianceElemental() : base("Hanusa, Radiance Elemental", 7, 9500, Interfaces.Race.AngelCommand, Interfaces.Civilization.Light)
        {
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
