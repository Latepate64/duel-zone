using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class SlashAndBurn : Spell
{
    public SlashAndBurn() : base("Slash and Burn", 4, Civilization.Darkness, Civilization.Fire)
    {
        AddSpellAbilities(new SlashAndBurnEffect());
    }
}
