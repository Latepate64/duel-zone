using Interfaces;

namespace StaticAbilities;

public class SlayerAbilityFactory
{
    public SlayerAbility Create()
    {
        return new SlayerAbility();
    }

    public SlayerAbility Create(ICardFilter cardFilter)
    {
        return new SlayerAbility(cardFilter);
    }
}