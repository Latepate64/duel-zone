namespace Engine.ContinuousEffects
{
    public class PowerAttackerEffect : ContinuousEffect
    {
        public int Power { get; }

        public PowerAttackerEffect(PowerAttackerEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public PowerAttackerEffect(int power)
        {
            Power = power;
        }

        public override ContinuousEffect Copy()
        {
            return new PowerAttackerEffect(this);
        }

        public virtual int GetPower(Game game, Player player)
        {
            return Power;
        }

        public override string ToString()
        {
            return $"Power attacker +{Power} (While attacking, this creature gets +{Power} power.)";
        }
    }
}
