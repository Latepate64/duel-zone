using Common;

namespace Cards.Cards.DM05
{
    class SyriusFirmamentElemental : Creature
    {
        public SyriusFirmamentElemental() : base("Syrius, Firmament Elemental", 11, 12000, Subtype.AngelCommand, Civilization.Light)
        {
            AddBlockerAbility();
            AddTripleBreakerAbility();
        }
    }
}
