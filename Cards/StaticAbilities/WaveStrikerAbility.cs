using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class WaveStrikerAbility(params IAbility[] abilities) : StaticAbility(new WaveStrikerEffect(abilities))
    {
    }
}
