using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.TriggeredAbilities
{
    class IllusionaryMerfolkAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public IllusionaryMerfolkAbility() : base(new YouMayDrawCardsEffect(3))
        {
        }

        public IllusionaryMerfolkAbility(IllusionaryMerfolkAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new IllusionaryMerfolkAbility(this);
        }

        public override bool CheckInterveningIfClause(IGame game)
        {
            // if you have a Cyber Lord in the battle zone
            return game.BattleZone.GetCreatures(Controller).Any(x => x.Subtypes.Contains(Common.Subtype.CyberLord));
        }
    }
}
