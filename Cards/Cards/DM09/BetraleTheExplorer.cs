using Cards.OneShotEffects;

namespace Cards.Cards.DM09
{
    class BetraleTheExplorer : Creature
    {
        public BetraleTheExplorer() : base("Betrale, the Explorer", 5, 5000, Engine.Subtype.Gladiator, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
            AddAtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect());
        }
    }
}
