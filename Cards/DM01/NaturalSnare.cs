using Engine;
using Interfaces;

namespace Cards.DM01;

public sealed class NaturalSnare : Spell
{
    public NaturalSnare() : base("Natural Snare", 6, Civilization.Nature)
    {
        AddShieldTrigger();
        AddSpellAbilities(new NaturalSnareEffect());
    }
}
