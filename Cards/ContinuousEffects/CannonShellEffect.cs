using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class CannonShellEffect : PowerModifyingEffect
    {
        public CannonShellEffect(CannonShellEffect effect) : base(effect)
        {
        }

        public CannonShellEffect() : base(1000)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new CannonShellEffect(this);
        }

        public override void Apply(Game game)
        {
            foreach (var card in game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(card.Owner))))
            {
                card.Power += game.GetPlayer(card.Owner).ShieldZone.Cards.Count * _power;
            }
        }

        public override string ToString()
        {
            return $"{Filter} gets +{_power} power for each shield you have.";
        }
    }
}
