using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class WaveStrikerAbility : StaticAbility
    {
        public WaveStrikerAbility(params IAbility[] abilities) : base(new WaveStrikerEffect(abilities))
        {
        }
    }
}
