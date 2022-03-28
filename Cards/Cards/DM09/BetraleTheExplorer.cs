using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM09
{
    class BetraleTheExplorer : Creature
    {
        public BetraleTheExplorer() : base("Betrale, the Explorer", 5, 5000, Subtype.Gladiator, Civilization.Light)
        {
            AddAbilities(new BlockerAbility(), new ThisCreatureCannotAttackPlayersAbility(), new AtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect()));
        }
    }
}
