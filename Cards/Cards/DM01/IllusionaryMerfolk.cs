using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM01
{
    class IllusionaryMerfolk : Creature
    {
        public IllusionaryMerfolk() : base("Illusionary Merfolk", 5, 4000, Race.GelFish, Civilization.Water)
        {
            AddTriggeredAbility(new IllusionaryMerfolkAbility());
        }
    }

    class IllusionaryMerfolkAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public IllusionaryMerfolkAbility() : base(new YouMayDrawCardsEffect(3))
        {
        }

        public IllusionaryMerfolkAbility(IllusionaryMerfolkAbility ability) : base(ability)
        {
        }

        public override IAbility Copy()
        {
            return new IllusionaryMerfolkAbility(this);
        }

        public override bool CheckInterveningIfClause(IGame game)
        {
            return game.BattleZone.GetCreatures(Controller).Any(x => x.HasRace(Race.CyberLord));
        }

        public override string ToString()
        {
            return "When you put this creature into the battle zone, if you have a Cyber Lord in the battle zone, draw up to 3 cards.";
        }
    }
}
