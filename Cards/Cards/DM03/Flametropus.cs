using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM03
{
    class Flametropus : Creature
    {
        public Flametropus() : base("Flametropus", 4, 3000, Subtype.RockBeast, Civilization.Fire)
        {
            AddWheneverThisCreatureAttacksAbility(new FlametropusOneShotEffect());
        }
    }

    class FlametropusOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = new FlametropusManaEffect().Apply(game, source);
            if (cards.Any())
            {
                game.AddContinuousEffects(source, new FlametropusContinuousEffect(game.GetCard(source.Source)));                 
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new FlametropusOneShotEffect();
        }

        public override string ToString()
        {
            return "You may put a card from your mana zone into your graveyard. If you do, this creature gets \"power attacker +3000\" and \"double breaker\" until the end of the turn.";
        }
    }

    class FlametropusContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
    {
        public FlametropusContinuousEffect(FlametropusContinuousEffect effect) : base(effect)
        {
        }

        public FlametropusContinuousEffect(ICard card) : base(card, new PowerAttackerAbility(3000), new DoubleBreakerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new FlametropusContinuousEffect(this);
        }

        public override string ToString()
        {
            return "This creature gets \"power attacker +3000\" and \"double breaker\" until the end of the turn.";
        }
    }

    class FlametropusManaEffect : OneShotEffects.ManaBurnEffect
    {
        public FlametropusManaEffect() : base(0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new FlametropusManaEffect();
        }

        public override string ToString()
        {
            return "You may put a card from your mana zone into your graveyard.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.GetPlayer(source.Controller).ManaZone.Cards;
        }
    }
}
