using Engine.Durations;
using System.Linq;

namespace Engine.ContinuousEffects
{
    public class PowerModifyingEffect : CharacteristicModifyingEffect
    {
        protected readonly int _power;

        public PowerModifyingEffect(CardFilter filter, int power, Duration duration, params Condition[] conditions) : base(filter, duration, conditions)
        {
            _power = power;
        }

        public PowerModifyingEffect(int power, params Condition[] conditions) : this(new TargetFilter(), power, new Indefinite(), conditions) { }

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
                card.Power += GetPower(game);
            }
        }

        public override string ToString()
        {
            return $"{ToStringBase()}{Filter} gets +{_power} power{GetDurationAsText()}.";
        }

        protected virtual int GetPower(Game game)
        {
            return _power;
        }
    }
}
