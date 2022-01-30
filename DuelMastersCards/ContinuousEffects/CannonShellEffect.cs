using DuelMastersModels;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using DuelMastersModels.GameEvents;
using DuelMastersModels.Zones;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class CannonShellEffect : CharacteristicModifyingEffect
    {
        const int Increment = 1000;
        int _lastBuff;

        public CannonShellEffect(CannonShellEffect effect) : base(effect)
        {
            _lastBuff = effect._lastBuff;
        }

        public CannonShellEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new CannonShellEffect(this);
        }

        public override void Start(Game game)
        {
            var card = game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(card.Owner))).Single();
            _lastBuff = Increment * game.GetPlayer(card.Owner).ShieldZone.Cards.Count;
            card.Power += _lastBuff;
        }

        public override void End(Game game)
        {
            var card = game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(card.Owner))).Single();
            card.Power -= _lastBuff;
        }

        public override void Update(Game game, GameEvent e)
        {
            if (e is CardMovedEvent cardMoved)
            {
                var card = game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(card.Owner))).Single();
                if (card.Owner == game.GetCard(cardMoved.CardInDestinationZone)?.Owner)
                {
                    if (cardMoved.Source == ZoneType.ShieldZone)
                    {
                        _lastBuff -= Increment;
                        card.Power -= Increment;
                    }
                    if (cardMoved.Destination == ZoneType.ShieldZone)
                    {
                        _lastBuff += Increment;
                        card.Power += Increment;
                    }
                }
            }
        }
    }
}
