using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM06
{
    public class ZorvazTheBonecrusher : Creature
    {
        public ZorvazTheBonecrusher() : base("Zorvaz, the Bonecrusher", 5, Civilization.Darkness, 8000, Subtype.DemonCommand)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());

            // When this creature battles, destroy it after the battle.
            Abilities.Add(new TriggeredAbilities.BattleAbility(new DestroyAfterBattleEffect()));
        }
    }
}
