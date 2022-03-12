using Engine.Durations;
using System.Linq;

namespace Engine.ContinuousEffects
{
    public class PowerModifyingEffect : CharacteristicModifyingEffect
    {
        protected readonly int _power;

        public PowerModifyingEffect(CardFilter filter, int power, Duration duration) : base(filter, duration)
        {
            _power = power;
        }

        public PowerModifyingEffect(int power) : this(new TargetFilter(), power, new Indefinite()) { }

        public PowerModifyingEffect(PowerModifyingEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public override ContinuousEffect Copy()
        {
            return new PowerModifyingEffect(this);
        }

        public override void Apply(Game game)
        {
            foreach (var card in game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(card.Owner))))
            {
                card.Power += _power;
            }
        }

        public override string ToString()
        {
            return $"{Filter} gets +{_power} power{GetDurationAsText()}.";
        }
    }
}
