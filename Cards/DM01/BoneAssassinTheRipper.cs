using ContinuousEffects;

namespace Cards.DM01
{
    sealed class BoneAssassinTheRipper : Engine.Creature
    {
        public BoneAssassinTheRipper() : base("Bone Assassin, the Ripper", 4, 2000, Interfaces.Race.LivingDead, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}
