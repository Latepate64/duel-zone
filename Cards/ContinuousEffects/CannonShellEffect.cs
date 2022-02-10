using Common;
using Common.GameEvents;
using Engine;
using Engine.ContinuousEffects;
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

        public CannonShellEffect()
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
            if (e is CardMovedEvent cardMoved && cardMoved.CardInDestinationZone != null)
            {
                var card = game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(card.Owner))).Single();
                if (card.Owner == game.GetCard(cardMoved.CardInDestinationZone.Id)?.Owner)
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

        public override string ToString()
        {
            return $"This creature gets +{Increment} power for each shield you have.";
        }
    }
}
