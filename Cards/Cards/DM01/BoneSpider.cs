using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class BoneSpider : Creature
    {
        public BoneSpider() : base("Bone Spider", 3, 5000, Engine.Subtype.LivingDead, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenThisCreatureWinsBattleAbility(new OneShotEffects.DestroyThisCreatureEffect()));
        }
    }
}
