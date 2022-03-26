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
            AddAbilities(new BlockerAbility(), new ThisCreatureCannotAttackPlayersAbility(), new AtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect()));
        }
    }
}
