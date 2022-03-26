using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM06
{
    class ZorvazTheBonecrusher : Creature
    {
        public ZorvazTheBonecrusher() : base("Zorvaz, the Bonecrusher", 5, 8000, Subtype.DemonCommand, Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility(), new ThisCreatureCannotAttackAbility(), new TriggeredAbilities.WhenThisCreatureBattlesAbility(new DestroyAfterBattleEffect()));
        }
    }
}
