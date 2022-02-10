using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class BoneAssassinTheRipper : Creature
    {
        public BoneAssassinTheRipper() : base("Bone Assassin, the Ripper", 4, Common.Civilization.Darkness, 2000, Common.Subtype.LivingDead)
        {
            Abilities.Add(new SlayerAbility());
        }
    }
}
