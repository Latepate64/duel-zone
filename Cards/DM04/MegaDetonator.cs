using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM04
{
    class MegaDetonator : Spell
    {
        public MegaDetonator() : base("Mega Detonator", 2, Civilization.Fire)
        {
            AddSpellAbilities(new MegaDetonatorDiscardEffect());
        }
    }

    class MegaDetonatorDiscardEffect : OneShotEffect
    {
        public MegaDetonatorDiscardEffect()
        {
        }

        public MegaDetonatorDiscardEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var player = Controller;
            var amount = player.DiscardAnyNumberOfCards(game, Ability);
            var creatures = player.ChooseControlledCreatures(game, ToString(), amount);
            game.AddContinuousEffects(Ability, new MegaDetonatorContinuousEffect([.. creatures]));
        }

        public override IOneShotEffect Copy()
        {
            return new MegaDetonatorDiscardEffect(this);
        }

        public override string ToString()
        {
            return "Discard any number of cards from your hand. Then choose the same number of your creatures in the battle zone. Each of those creatures gets \"double breaker\" until the end of the turn.";
        }
    }

    class MegaDetonatorContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
    {
        public MegaDetonatorContinuousEffect(MegaDetonatorContinuousEffect effect) : base(effect)
        {
        }

        public MegaDetonatorContinuousEffect(params ICard[] cards) : base(
            new StaticAbility(new DoubleBreakerEffect()), cards)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MegaDetonatorContinuousEffect(this);
        }

        public override string ToString()
        {
            return "This creature gets \"double breaker\" until the end of the turn.";
        }
    }
}
