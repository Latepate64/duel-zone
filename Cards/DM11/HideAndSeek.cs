using Engine;
using Interfaces;

namespace Cards.DM11;

public sealed class HideAndSeek : Spell
{
    public HideAndSeek() : base("Hide and Seek", 4, Civilization.Water, Civilization.Darkness)
    {
        AddSpellAbilities(new HideAndSeekEffect());
    }
}
