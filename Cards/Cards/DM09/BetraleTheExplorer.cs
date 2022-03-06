using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Common;
using Engine;

namespace Cards.Cards.DM09
{
    class BetraleTheExplorer : Creature
    {
        public BetraleTheExplorer() : base("Betrale, the Explorer", 5, 5000, Subtype.Gladiator, Civilization.Light)
        {
            // At the end of each of your turns, you may untap this creature.
            AddAbilities(new BlockerAbility(), new CannotAttackPlayersAbility(), new AtTheEndOfYourTurnAbility(new ControllerMayUntapCreatureEffect(new TargetFilter())));
        }
    }
}
