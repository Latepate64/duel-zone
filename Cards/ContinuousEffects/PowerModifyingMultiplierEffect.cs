using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class PowerModifyingMultiplierEffect : PowerModifyingEffect
    {
        public ICardFilter Multiplier { get; set; }

        public PowerModifyingMultiplierEffect(int power, ICardFilter multiplier, params Condition[] conditions) : base(power, conditions)
        {
            Multiplier = multiplier;
        }

        public PowerModifyingMultiplierEffect(PowerModifyingMultiplierEffect effect) : base(effect)
        {
            Multiplier = effect.Multiplier.Copy();
        }

        public override string ToString()
        {
            return $"{Filter} gets +{_power} power for each {Multiplier}.";
        }

        protected override int GetPower(Game game)
        {
            return game.GetAllCards().Count(card => Multiplier.Applies(card, game, game.GetPlayer(card.Owner))) * _power;
        }
    }

    class PowerAttackerMultiplierEffect : PowerModifyingMultiplierEffect
    {
        public PowerAttackerMultiplierEffect(int power, CardFilter multiplier) : base(power, multiplier, new Conditions.AttackingCreatureCondition(new TargetFilter()))
        {
        }
    }
}
