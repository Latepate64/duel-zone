using Engine;
using Interfaces;

namespace Cards.DM11;

public class SlashAndBurn : Spell
{
    public SlashAndBurn() : base("Slash and Burn", 4, Civilization.Darkness, Civilization.Fire)
    {
        AddSpellAbilities(new SlashAndBurnEffect());
    }
}
