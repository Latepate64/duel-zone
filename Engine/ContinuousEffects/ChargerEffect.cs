namespace Engine.ContinuousEffects
{
    public class ChargerEffect : ContinuousEffect
    {
        public ChargerEffect(ICardFilter filter) : base(filter)
        {
        }

        public ChargerEffect(ChargerEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new ChargerEffect(this);
        }

        public override string ToString()
        {
            return "Charger";
        }
    }
}
