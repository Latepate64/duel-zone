using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    abstract class PowerModifyingMultiplierEffect : ContinuousEffect, IPowerModifyingEffect, IPowerable
    {
        protected PowerModifyingMultiplierEffect(int power) : base()
        {
            Power = power;
        }

        protected PowerModifyingMultiplierEffect(PowerModifyingMultiplierEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public int Power { get; }

        public virtual void ModifyPower(IGame game)
        {
            Source.Power += GetMultiplier(game) * Power;
        }

        protected abstract int GetMultiplier(IGame game);
    }

    abstract class PowerAttackerMultiplierEffect : PowerModifyingMultiplierEffect
    {
        protected PowerAttackerMultiplierEffect(int power) : base(power)
        {
        }

        protected PowerAttackerMultiplierEffect(PowerAttackerMultiplierEffect effect) : base(effect)
        {
        }

        public override void ModifyPower(IGame game)
        {
            var creature = Source;
            if (game.CurrentTurn.CurrentPhase is Engine.Steps.AttackPhase phase && phase.AttackingCreature == creature)
            {
                creature.Power += GetMultiplier(game) * Power;
            }
        }
    }

    class DogarnTheMarauderEffect : PowerAttackerMultiplierEffect
    {
        public DogarnTheMarauderEffect(int power) : base(power)
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
            return $"While attacking, this creature gets +{Power} power for each other tapped creature you have in the battle zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.BattleZone.GetOtherTappedCreatures(Applier.Id, Source.Id).Count();
        }
    }

    class ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures : PowerModifyingMultiplierEffect
    {
        public ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures effect) : base(effect)
        {
        }

        public ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(int power) : base(power)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(this);
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power for each of your other untapped creatures in the battle zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.BattleZone.GetOtherUntappedCreatures(Applier.Id, Source.Id).Count();
        }
    }

    class JigglyTotemEffect : PowerAttackerMultiplierEffect
    {
        public JigglyTotemEffect(JigglyTotemEffect effect) : base(effect)
        {
        }

        public JigglyTotemEffect(int power) : base(power)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new JigglyTotemEffect(this);
        }

        public override string ToString()
        {
            return $"While attacking, this creature gets +{Power} power for each tapped card in your mana zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return Ability.Controller.ManaZone.TappedCards.Count();
        }
    }
}
