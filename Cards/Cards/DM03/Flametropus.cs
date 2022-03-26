using Cards.StaticAbilities;
using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;
using System.Linq;

namespace Cards.Cards.DM03
{
    class Flametropus : Creature
    {
        public Flametropus() : base("Flametropus", 4, 3000, Subtype.RockBeast, Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new FlametropusOneShotEffect()));
        }
    }

    class FlametropusOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = new OneShotEffects.SelfManaBurnEffect(0, 1).Apply(game, source);
            if (cards.Any())
            {
                game.AddContinuousEffects(source, new FlametropusContinuousEffect(new TargetFilter { Target = source.Source }));                 
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

    class FlametropusContinuousEffect : AbilityAddingEffect
    {
        public FlametropusContinuousEffect(FlametropusContinuousEffect effect) : base(effect)
        {
        }

        public FlametropusContinuousEffect(ICardFilter filter) : base(filter, new UntilTheEndOfTheTurn(), new PowerAttackerAbility(3000), new DoubleBreakerAbility())
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
}
