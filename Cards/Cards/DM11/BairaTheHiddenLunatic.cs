using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM11
{
    class BairaTheHiddenLunatic : Creature
    {
        public BairaTheHiddenLunatic() : base("Baira, the Hidden Lunatic", 3, 5000, Subtype.PandorasBox, Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility(), new CannotAttackCreaturesAbility(), new CannotAttackPlayersAbility(), new TriggeredAbilities.BattleAbility(new DestroyAfterBattleEffect())); // When this creature battles, destroy it after the battle.
        }
    }
}
