using Interfaces;

namespace StaticAbilities;

public class SpeedAttackerAbilityFactory
{
    public ISpeedAttackerAbility Create()
    {
        return new SpeedAttackerAbility();
    }
}