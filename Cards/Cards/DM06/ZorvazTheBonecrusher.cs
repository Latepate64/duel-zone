using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM06
{
    class ZorvazTheBonecrusher : Creature
    {
        public ZorvazTheBonecrusher() : base("Zorvaz, the Bonecrusher", 5, 8000, Subtype.DemonCommand, Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility(), new ThisCreatureCannotAttackCreaturesAbility(), new CannotAttackPlayersAbility(), new TriggeredAbilities.BattleAbility(new DestroyAfterBattleEffect())); // When this creature battles, destroy it after the battle.
        }
    }
}
