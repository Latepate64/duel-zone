using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM06
{
    class ZorvazTheBonecrusher : Creature
    {
        public ZorvazTheBonecrusher() : base("Zorvaz, the Bonecrusher", 5, 8000, Engine.Subtype.DemonCommand, Engine.Civilization.Darkness)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
            AddTriggeredAbility(new WhenThisCreatureBattlesAbility(new DestroyAfterBattleEffect()));
        }
    }
}
