namespace Cards.StaticAbilities
{
    class GalsaurAbility : Engine.Abilities.StaticAbility
    {
        public GalsaurAbility() : base(new ContinuousEffects.GalsaurEffect())
        {
        }
    }
}
