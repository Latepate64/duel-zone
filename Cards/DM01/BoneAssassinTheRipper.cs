using ContinuousEffects;

namespace Cards.DM01
{
    class BoneAssassinTheRipper : Engine.Creature
    {
        public BoneAssassinTheRipper() : base("Bone Assassin, the Ripper", 4, 2000, Engine.Race.LivingDead, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}
