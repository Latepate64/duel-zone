using Engine;
using Interfaces;

namespace Cards.DM09;

public class ManaBonanza : Spell
{
    public ManaBonanza() : base("Mana Bonanza", 8, Civilization.Nature)
    {
        AddSpellAbilities(new ManaBonanzaEffect());
    }
}
