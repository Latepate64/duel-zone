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

        protected PowerAttackerMultiplierEffect(PowerAttackerMultiplierEffect effect) : base(effect)
        {
        }
    }

    class DogarnTheMarauderEffect : PowerAttackerMultiplierEffect
    {
        public DogarnTheMarauderEffect(int power) : base(power, new CardFilters.OwnersBattleZoneTappedCreatureExceptFilter())
        {
        }

        public DogarnTheMarauderEffect(DogarnTheMarauderEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new DogarnTheMarauderEffect(this);
        }

        public override string ToString()
        {
            return $"While attacking, this creature gets +{_power} power for each other tapped creature you have in the battle zone.";
        }
    }

    class ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures : PowerModifyingMultiplierEffect
    {
        public ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures effect) : base(effect)
        {
        }

        public ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(int power) : base(power, new CardFilters.OwnersOtherBattleZoneUntappedCreatureFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(this);
        }

        public override string ToString()
        {
            return $"This creature gets +{_power} power for each of your other untapped creatures in the battle zone.";
        }
    }

    class JigglyTotemEffect : PowerAttackerMultiplierEffect
    {
        public JigglyTotemEffect(JigglyTotemEffect effect) : base(effect)
        {
        }

        public JigglyTotemEffect(int power) : base(power, new CardFilters.OwnersManaZoneTappedCardFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new JigglyTotemEffect(this);
        }

        public override string ToString()
        {
            return $"While attacking, this creature gets +{_power} power for each tapped card in your mana zone.";
        }
    }
}
