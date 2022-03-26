using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM01
{
    class BoneSpider : Creature
    {
        public BoneSpider() : base("Bone Spider", 3, 5000, Subtype.LivingDead, Civilization.Darkness)
        {
            AddAbilities(new WhenThisCreatureWinsBattleAbility(new OneShotEffects.DestroyThisCreatureEffect()));
        }
    }
}
