using ContinuousEffects;
using Cards.OneShotEffects;
using Abilities.Triggered;

namespace Cards.Cards.DM01
{
    class RubyGrass : Engine.Creature
    {
        public RubyGrass() : base("Ruby Grass", 3, 3000, Engine.Race.StarlightTree, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect()));
        }
    }
}
