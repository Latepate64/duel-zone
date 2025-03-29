using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class WaveStrikerAbility : StaticAbility
    {
        public WaveStrikerAbility(params IAbility[] abilities) : base(new WaveStrikerEffect(abilities))
        {
        }
    }
}
