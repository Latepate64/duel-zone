using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    class BoneAssassinTheRipper : Creature
    {
        public BoneAssassinTheRipper() : base("Bone Assassin, the Ripper", 4, Civilization.Darkness, 2000, Subtype.LivingDead)
        {
            Abilities.Add(new SlayerAbility());
        }
    }
}
