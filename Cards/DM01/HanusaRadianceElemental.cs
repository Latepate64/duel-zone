using ContinuousEffects;

namespace Cards.DM01
{
    class HanusaRadianceElemental : Engine.Creature
    {
        public HanusaRadianceElemental() : base("Hanusa, Radiance Elemental", 7, 9500, Interfaces.Race.AngelCommand, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
