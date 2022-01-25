using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using System.Linq;

namespace DuelMastersCards.TriggeredAbilities
{
    class IllusionaryMerfolkAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public IllusionaryMerfolkAbility() : base(new ControllerMayDrawCardsEffect(3))
        {
        }

        public IllusionaryMerfolkAbility(IllusionaryMerfolkAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new IllusionaryMerfolkAbility(this);
        }

        public override bool CheckInterveningIfClause(Game game)
        {
            // if you have a Cyber Lord in the battle zone
            return game.BattleZone.GetCreatures(Owner).Any(x => x.Subtypes.Contains(Subtype.CyberLord));
        }
    }
}
