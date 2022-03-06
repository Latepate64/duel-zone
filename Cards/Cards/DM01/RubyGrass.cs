using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    class RubyGrass : Creature
    {
        public RubyGrass() : base("Ruby Grass", 3, 3000, Common.Subtype.StarlightTree, Common.Civilization.Light)
        {
            // At the end of each of your turns, you may untap this creature.
            AddAbilities(new BlockerAbility(), new CannotAttackPlayersAbility(), new AtTheEndOfYourTurnAbility(new ControllerMayUntapCreatureEffect(new TargetFilter())));
        }
    }
}
