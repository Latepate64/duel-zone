using ContinuousEffects;
using OneShotEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class SnakeAttack : Spell
    {
        public SnakeAttack() : base("Snake Attack", 4, Civilization.Darkness)
        {
            AddSpellAbilities(new SnakeAttackEffect(), new ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
        }
    }

    class SnakeAttackEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Ability, new ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect([.. game.BattleZone.GetCreatures(Ability.Controller.Id)]));
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

    class ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect : AddAbilitiesUntilEndOfTurnEffect
    {
        public ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(params Card[] cards) : base(new StaticAbility(
            new DoubleBreakerEffect()), cards)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return "This creature has \"double breaker\" until the end of the turn.";
        }
    }
}
