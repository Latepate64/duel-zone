using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class GigastandAbility : StaticAbility
    {
        public GigastandAbility() : base(new ContinuousEffects.GigastandEffect())
        {
        }
    }
}
