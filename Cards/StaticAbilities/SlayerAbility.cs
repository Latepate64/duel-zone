using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class SlayerAbility : StaticAbility
    {
        public SlayerAbility() : base(new ContinuousEffects.ThisCreatureHasSlayerEffect())
        {
        }
    }
}
