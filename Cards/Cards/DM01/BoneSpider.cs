using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;
using Engine;

namespace Cards.Cards.DM01
{
    class BoneSpider : Creature
    {
        public BoneSpider() : base("Bone Spider", 3, 5000, Subtype.LivingDead, Civilization.Darkness)
        {
            // When this creature wins a battle, destroy it.
            var targetFilter = new TargetFilter();
            Abilities.Add(new WinBattleAbility(new DestroyAreaOfEffect(targetFilter)));
        }
    }
}
