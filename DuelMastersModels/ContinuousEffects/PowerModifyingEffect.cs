using DuelMastersModels.Durations;
using DuelMastersModels.GameEvents;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.ContinuousEffects
{
    public class PowerModifyingEffect : CharacteristicModifyingEffect
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

        public override void Start(Game game)
        {
            foreach (var card in game.GetAllCards().Where(card => Filters.All(f => f.Applies(card, game, game.GetPlayer(card.Owner)))))
            {
                card.Power += _power;
            }
        }

        public override void End(Game game)
        {
            foreach (var card in game.GetAllCards().Where(card => Filters.All(f => f.Applies(card, game, game.GetPlayer(card.Owner)))))
            {
                card.Power -= _power;
            }
        }

        public override void Update(Game game, GameEvent e)
        {
            if (e is CardMovedEvent cme)
            {
                var card = game.GetCard(cme.CardInDestinationZone);
                if (Filters.All(f => f.Applies(card, game, game.GetPlayer(card.Owner))))
                {
                    if (cme.Destination == Zones.ZoneType.BattleZone)
                    {
                        card.Power += _power;
                    }
                    if (cme.Source == Zones.ZoneType.BattleZone)
                    {
                        card.Power -= _power;
                    }
                }
            }
        }
    }
}
