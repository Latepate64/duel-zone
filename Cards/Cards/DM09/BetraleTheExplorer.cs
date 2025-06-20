using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Abilities.Triggered;
using ContinuousEffects;

namespace Cards.Cards.DM09
{
    class BetraleTheExplorer : Engine.Creature
    {
        public BetraleTheExplorer() : base("Betrale, the Explorer", 5, 5000, Engine.Race.Gladiator, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect()));
        }
    }
}
