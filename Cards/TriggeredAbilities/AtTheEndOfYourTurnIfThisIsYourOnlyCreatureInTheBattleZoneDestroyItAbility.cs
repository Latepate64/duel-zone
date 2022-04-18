using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.TriggeredAbilities
{
    class AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility : AtTheEndOfYourTurnAbility
    {
        public AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility() : base(new OneShotEffects.DestroyThisCreatureEffect())
        {
        }

        public AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility(AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility ability) : base(ability)
        {
        }

        public override bool CheckInterveningIfClause(IGame game)
        {
            return !game.BattleZone.GetCreatures(Controller).Any(x => x.Id != Source);
        }

        public override IAbility Copy()
        {
            return new AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility(this);
        }

        public override string ToString()
        {
            return "At the end of each of your turns, if this is your only creature in the battle zone, destroy it.";
        }
    }
}