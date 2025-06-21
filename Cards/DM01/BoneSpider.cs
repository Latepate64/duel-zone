using TriggeredAbilities;

namespace Cards.DM01
{
    class BoneSpider : Engine.Creature
    {
        public BoneSpider() : base("Bone Spider", 3, 5000, Interfaces.Race.LivingDead, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenThisCreatureWinsBattleAbility(new OneShotEffects.DestroyThisCreatureEffect()));
        }
    }
}
