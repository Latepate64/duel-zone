using Abilities.Static;

namespace Cards.DM01
{
    sealed class BoneAssassinTheRipper : Creature
    {
        public BoneAssassinTheRipper() : base("Bone Assassin, the Ripper", 4, 2000, Interfaces.Race.LivingDead, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new SlayerAbility());
        }
    }
}
