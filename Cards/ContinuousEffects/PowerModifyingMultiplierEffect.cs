using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    abstract class PowerModifyingMultiplierEffect : PowerModifyingEffect
    {
        public ICardFilter Multiplier { get; set; }

        protected PowerModifyingMultiplierEffect(int power, ICardFilter multiplier, params Condition[] conditions) : base(power, new Durations.Indefinite(), conditions)
        {
            Multiplier = multiplier;
        }

        protected PowerModifyingMultiplierEffect(PowerModifyingMultiplierEffect effect) : base(effect)
        {
            Multiplier = effect.Multiplier.Copy();
        }

        protected override int GetPower(IGame game)
        {
            return game.GetAllCards().Count(card => Multiplier.Applies(card, game, game.GetPlayer(card.Owner))) * _power;
        }
    }

    abstract class PowerAttackerMultiplierEffect : PowerModifyingMultiplierEffect
    {
        protected PowerAttackerMultiplierEffect(int power, CardFilter multiplier) : base(power, multiplier, new Conditions.AttackingCreatureCondition(new TargetFilter()))
        {
        }
    }

    class DogarnTheMarauderEffect : ContinuousEffects.PowerAttackerMultiplierEffect
    {
        public DogarnTheMarauderEffect() : base(2000, new CardFilters.OwnersBattleZoneTappedCreatureExceptFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new DogarnTheMarauderEffect();
        }

        public override string ToString()
        {
            return "While attacking, this creature gets +2000 power for each other tapped creature you have in the battle zone.";
        }
    }
}
