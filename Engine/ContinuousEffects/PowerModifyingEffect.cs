using Common.GameEvents;
using Engine.Durations;
using System.Linq;

namespace Engine.ContinuousEffects
{
    public class PowerModifyingEffect : CharacteristicModifyingEffect
    {
        private readonly int _power;

        public PowerModifyingEffect(CardFilter filter, int power, Duration duration) : base(filter, duration)
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

        public override void Start(Game game)
        {
            foreach (var card in game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(card.Owner))))
            {
                card.Power += _power;
            }
        }

        public override void End(Game game)
        {
            foreach (var card in game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(card.Owner))))
            {
                card.Power -= _power;
            }
        }

        public override void Update(Game game, GameEvent e)
        {
            if (e is CardMovedEvent cme)
            {
                var card = game.GetCard(cme.CardInDestinationZone);
                if (Filter.Applies(card, game, game.GetOwner(card)))
                {
                    if (cme.Destination == Common.ZoneType.BattleZone)
                    {
                        card.Power += _power;
                    }
                    if (cme.Source == Common.ZoneType.BattleZone)
                    {
                        card.Power -= _power;
                    }
                }
            }
        }
    }
}
