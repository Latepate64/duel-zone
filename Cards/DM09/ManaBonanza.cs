using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class ManaBonanza : Spell
{
    public ManaBonanza() : base("Mana Bonanza", 8, Civilization.Nature)
    {
        AddSpellAbilities(new ManaBonanzaEffect());
    }
}
