using ContinuousEffects;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09
{
    class BetraleTheExplorer : Engine.Creature
    {
        public BetraleTheExplorer() : base("Betrale, the Explorer", 5, 5000, Interfaces.Race.Gladiator, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect()));
        }
    }
}
