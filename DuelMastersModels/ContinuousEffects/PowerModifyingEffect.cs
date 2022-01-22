using DuelMastersModels.Durations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.ContinuousEffects
{
    public class PowerModifyingEffect : ContinuousEffect
    {
        private readonly int _power;

        public PowerModifyingEffect(CardFilter filter, int power, Duration duration) : base(filter, duration)
        {
            _power = power;
        }

        public PowerModifyingEffect(IEnumerable<CardFilter> filters, int power, Duration duration) : base(filters, duration)
        {
            _power = power;
        }

        public PowerModifyingEffect(PowerModifyingEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public override ContinuousEffect Copy()
        {
            return new PowerModifyingEffect(this);
        }

        public virtual int GetPower(Game game)
        {
            return _power;
        }

        public override void Start(Guid ability, Game game)
        {
            base.Start(ability, game);
            var cards = game.GetAllCards().Where(card => Filters.All(f => f.Applies(card, game, game.GetPlayer(card.Owner))));
            foreach (var card in cards)
            {
                card.Power += _power;
            }
        }

        public override void End(Game game)
        {
            base.End(game);
            var cards = game.GetAllCards().Where(card => Filters.All(f => f.Applies(card, game, game.GetPlayer(card.Owner))));
            foreach (var card in cards)
            {
                card.Power -= _power;
            }
        }
    }
}
