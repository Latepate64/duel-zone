using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    class ThisCreatureGetsPowerAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureGetsPowerAbility(int power) : base(new ThisCreatureGetsPowerEffect(power))
        {
        }
    }

    class ThisCreatureGetsPowerEffect : PowerModifyingEffect
    {
        public ThisCreatureGetsPowerEffect(ThisCreatureGetsPowerEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetsPowerEffect(int power) : base(power, new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerEffect(this);
        }

        public override string ToString()
        {
            return $"This creature gets +{_power} power.";
        }
    }
}
