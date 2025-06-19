using Cards.ContinuousEffects;
using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class RubyGrass : Creature
    {
        public RubyGrass() : base("Ruby Grass", 3, 3000, Engine.Race.StarlightTree, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddAtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect());
        }
    }
}
