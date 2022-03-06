using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM06
{
    class ZorvazTheBonecrusher : Creature
    {
        public ZorvazTheBonecrusher() : base("Zorvaz, the Bonecrusher", 5, Civilization.Darkness, 8000, Subtype.DemonCommand)
        {
            AddAbilities(new BlockerAbility(), new CannotAttackCreaturesAbility(), new CannotAttackPlayersAbility(), new TriggeredAbilities.BattleAbility(new DestroyAfterBattleEffect())); // When this creature battles, destroy it after the battle.
        }
    }
}
