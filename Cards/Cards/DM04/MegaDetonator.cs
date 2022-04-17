using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM04
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
        public override object Apply(IGame game, IAbility source)
        {
            var discarded = new DiscardAnyNumberOfCardsEffect().Apply(game, source);
            return new MegaDetonatorBuffEffect(discarded.Count()).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new MegaDetonatorDiscardEffect();
        }

        public override string ToString()
        {
            return "Discard any number of cards from your hand. Then choose the same number of your creatures in the battle zone. Each of those creatures gets \"double breaker\" until the end of the turn.";
        }
    }

    class MegaDetonatorBuffEffect : CardSelectionEffect
    {
        private readonly int _amount;

        public MegaDetonatorBuffEffect(int amount) : base(amount, amount, true)
        {
            _amount = amount;
        }

        public MegaDetonatorBuffEffect(MegaDetonatorBuffEffect effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public override IOneShotEffect Copy()
        {
            return new MegaDetonatorBuffEffect(this);
        }

        public override string ToString()
        {
            return $"Choose {_amount} of your creatures in the battle zone. Each of those creatures gets \"double breaker\" until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddContinuousEffects(source, new MegaDetonatorContinuousEffect(cards));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller);
        }
    }

    class MegaDetonatorContinuousEffect : ContinuousEffects.AddAbilitiesUntilEndOfTurnEffect
    {
        public MegaDetonatorContinuousEffect(MegaDetonatorContinuousEffect effect) : base(effect)
        {
        }

        public MegaDetonatorContinuousEffect(params ICard[] cards) : base(new StaticAbilities.DoubleBreakerAbility(), cards)
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
