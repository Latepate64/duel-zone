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
            AddAbilities(new TriggeredAbilities.AttackAbility(new FlametropusEffect()));
        }
    }

    class FlametropusEffect : OneShotEffect
    {
        public override object Apply(Game game, Ability source)
        {
            var cards = new OneShotEffects.SelfManaBurnEffect(0, 1).Apply(game, source);
            if (cards.Any())
            {
                game.AddContinuousEffects(source, new AbilityGrantingEffect(new TargetFilter { Target = source.Source }, new UntilTheEndOfTheTurn(), new PowerAttackerAbility(3000), new DoubleBreakerAbility()));                 
            }
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new FlametropusEffect();
        }

        public override string ToString()
        {
            return "You may put a card from your mana zone into your graveyard. If you do, this creature gets \"power attacker +3000\" and \"double breaker\" until the end of the turn.";
        }
    }
}
