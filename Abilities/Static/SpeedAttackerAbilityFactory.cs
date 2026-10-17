using Interfaces;

namespace Abilities.Static;

public class SpeedAttackerAbilityFactory
{
    public ISpeedAttackerAbility Create()
    {
        return new SpeedAttackerAbility();
    }
}