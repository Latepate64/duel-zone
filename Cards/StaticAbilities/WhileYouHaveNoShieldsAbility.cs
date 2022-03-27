using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class WhileYouHaveNoShieldsAbility : StaticAbility
    {
        public WhileYouHaveNoShieldsAbility(params IAbility[] abilities) : base(new ContinuousEffects.WhileYouHaveNoShieldsEffect(abilities))
        {
        }
    }
}
