using Interfaces;

namespace Cards.DM08;

public sealed class LunarCharger : Charger
{
    public LunarCharger() : base("Lunar Charger", 3, Civilization.Light)
    {
        AddSpellAbilities(new LunarChargerEffect());
    }
}
