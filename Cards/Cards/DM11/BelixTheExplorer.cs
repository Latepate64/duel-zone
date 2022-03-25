using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM11
{
    class BelixTheExplorer : Creature
    {
        public BelixTheExplorer() : base("Belix, the Explorer", 2, 3000, Subtype.Gladiator, Civilization.Light)
        {
            AddAbilities(new BlockerAbility(), new PutIntoPlayAbility(new OneShotEffects.ManaSpellRecoveryEffect(true)), new ThisCreatureCannotAttackPlayersAbility());
        }
    }
}
