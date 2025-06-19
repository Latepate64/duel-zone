using Effects.Continuous;
using Engine.Abilities;

namespace Abilities.Static;

public class WaveStrikerAbility(params IAbility[] abilities) : StaticAbility(new WaveStrikerEffect(abilities))
{
}
