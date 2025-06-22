using Interfaces;

namespace Cards.DM09;

public class SlashCharger : Charger
{
    public SlashCharger() : base("Slash Charger", 3, Civilization.Darkness)
    {
        AddSpellAbilities(new SlashChargerEffect());
    }
}
