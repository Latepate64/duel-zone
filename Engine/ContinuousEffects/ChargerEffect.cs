namespace Engine.ContinuousEffects
{
    public class ChargerEffect : ContinuousEffect
    {
        public ChargerEffect()
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
            return "Charger (After you cast this spell, put it into your mana zone instead of your graveyard.)";
        }
    }
}
