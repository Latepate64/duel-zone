using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM03
{
    class SnakeAttack : Spell
    {
        public SnakeAttack() : base("Snake Attack", 4, Common.Civilization.Darkness)
        {
            AddSpellAbilities(new SnakeAttackEffect(), new ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
        }
    }

    class SnakeAttackEffect : OneShotAreaOfEffect
    {
        public SnakeAttackEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter())
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(GetAffectedCards(game, source).ToArray()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new SnakeAttackEffect();
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone gets \"double breaker\" until the end of the turn.";
        }
    }

    class ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect : AbilityAddingEffect
    {
        public ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(AbilityAddingEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(params ICard[] cards) : base(new CardFilters.TargetsFilter(cards), new Durations.UntilTheEndOfTheTurn(), new DoubleBreakerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect();
        }

        public override string ToString()
        {
            return "This creature has \"double breaker\" until the end of the turn.";
        }
    }
}
