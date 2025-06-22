using Engine;
using Interfaces;

namespace Cards.DM06;

public sealed class InnocentHunterBladeOfAll : Creature
{
    public InnocentHunterBladeOfAll() : base(
        "Innocent Hunter, Blade of All", 4, 1000, Race.BeastFolk, Civilization.Nature)
    {
        AddStaticAbilities(new InnocentHunterEffect());
    }
}
