using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.Promo
{
    class NeveTheLeveler : Creature
    {
        public NeveTheLeveler() : base("Neve, the Leveler", 6, 4000, Subtype.SnowFaerie, Civilization.Nature)
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
            return game.BattleZone.GetCreatures(Controller).Count() > game.BattleZone.GetCreatures(GetOpponent(game).Id).Count();
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
        public override object Apply(IGame game, IAbility source)
        {
            var diff = game.BattleZone.GetCreatures(source.Controller).Count() - game.BattleZone.GetCreatures(source.GetOpponent(game).Id).Count();
            return new OneShotEffects.BrutalChargeSearchEffect(diff).Apply(game, source);
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
