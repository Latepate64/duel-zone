using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM11
{
    public class BairaTheHiddenLunatic : Creature
    {
        public BairaTheHiddenLunatic() : base("Baira, the Hidden Lunatic", 3, Civilization.Darkness, 5000, Subtype.PandorasBox)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());

            // When this creature battles, destroy it after the battle.
            Abilities.Add(new TriggeredAbilities.BattleAbility(new DestroyAfterBattleEffect()));
        }
    }
}
