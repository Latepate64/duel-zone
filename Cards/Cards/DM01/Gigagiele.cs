using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class Gigagiele : Creature
    {
        public Gigagiele() : base("Gigagiele", 5, Common.Civilization.Darkness, 3000, Common.Subtype.Chimera)
        {
            Abilities.Add(new SlayerAbility());
        }
    }
}
