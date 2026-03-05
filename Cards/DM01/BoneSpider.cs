using TriggeredAbilities;

namespace Cards.DM01
{
    sealed class BoneSpider : Creature
    {
        public BoneSpider() : base("Bone Spider", 3, 5000, Interfaces.Race.LivingDead, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenThisCreatureWinsBattleAbility(new OneShotEffects.DestroyThisCreatureEffect()));
        }
    }
}
