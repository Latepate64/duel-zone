namespace Engine.Abilities
{
    public class TapAbility : ActivatedAbility
    {
        public TapAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public TapAbility(TapAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new TapAbility(this);
        }

        public override string ToString()
        {
            return $"Instead of having this creature attack, you may tap it to use its Tap ability. Tap: {OneShotEffect}";
        }
    }
}
