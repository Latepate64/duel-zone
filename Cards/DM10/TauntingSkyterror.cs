using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class TauntingSkyterror : Creature
{
    public TauntingSkyterror() : base("Taunting Skyterror", 5, 3000, Race.ArmoredWyvern, Civilization.Fire)
    {
        AddStaticAbilities(new TauntingSkyterrorEffect());
    }
}
