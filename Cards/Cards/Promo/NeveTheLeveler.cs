using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.Promo
{
    class NeveTheLeveler : Creature
    {
        public NeveTheLeveler() : base("Neve, the Leveler", 6, 4000, Race.SnowFaerie, Civilization.Nature)
        {
            AddTriggeredAbility(new NeveTheLevelerAbility(new NeveTheLevelerEffect()));
        }
    }

    class NeveTheLevelerAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public NeveTheLevelerAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public NeveTheLevelerAbility(NeveTheLevelerAbility ability) : base(ability)
        {
        }

        public override bool CheckInterveningIfClause(IGame game)
        {
            return game.GetBattleZoneCreatures(GetOpponent(game)).Count() > game.GetBattleZoneCreatures(Controller).Count();
        }

        public override IAbility Copy()
        {
            return new NeveTheLevelerAbility(this);
        }

        public override string ToString()
        {
            return $"When you put this creature into the battle zone, if your opponent has more creatures in the battle zone than you do, {GetEffectText()}";
        }
    }

    class NeveTheLevelerEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            Controller.SearchOwnDeck();
            Controller.TakeCreaturesFromOwnDeckShowThemToOpponentAndPutThemIntoOwnHand(0, game.GetAmountOfBattleZoneCreatures(GetOpponent(game)) - game.GetAmountOfBattleZoneCreatures(Controller), ToString(), game, Ability);
            Controller.ShuffleOwnDeck(game);
        }

        public override IOneShotEffect Copy()
        {
            return new NeveTheLevelerEffect();
        }

        public override string ToString()
        {
            return "Search your deck. For each extra creature he has, you may take a creature from your deck, show that creature to your opponent, and put it into your hand. Then shuffle your deck.";
        }
    }
}
