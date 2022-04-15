using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class RubyGrass : Creature
    {
        public RubyGrass() : base("Ruby Grass", 3, 3000, Engine.Subtype.StarlightTree, Common.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
            AddAtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect());
        }
    }
}
