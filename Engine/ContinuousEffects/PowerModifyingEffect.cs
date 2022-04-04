using System.Linq;

namespace Engine.ContinuousEffects
{
    public abstract class PowerModifyingEffect : ContinuousEffect, IPowerModifyingEffect
    {
        protected readonly int _power;

        public PowerModifyingEffect(int power, ICardFilter filter, IDuration duration, params Condition[] conditions) : base(filter, duration, conditions)
        {
            _power = power;
        }

        public PowerModifyingEffect(int power, IDuration duration, params Condition[] conditions) : this(power, new TargetFilter(), duration, conditions) { }

        public PowerModifyingEffect(PowerModifyingEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        protected virtual int GetPower(IGame game)
        {
            return _power;
        }

        public void ModifyPower(IGame game)
        {
            foreach (var card in game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(card.Owner))))
            {
                card.Power += GetPower(game);
            }
        }
    }
}
