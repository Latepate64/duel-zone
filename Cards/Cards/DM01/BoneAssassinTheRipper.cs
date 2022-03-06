using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class BoneAssassinTheRipper : Creature
    {
        public BoneAssassinTheRipper() : base("Bone Assassin, the Ripper", 4, 2000, Common.Subtype.LivingDead, Common.Civilization.Darkness)
        {
            AddAbilities(new SlayerAbility());
        }
    }
}
