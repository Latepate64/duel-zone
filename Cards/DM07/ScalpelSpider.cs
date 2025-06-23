using Engine;
using Interfaces;

namespace Cards.DM07;

sealed class ScalpelSpider : Creature
{
    public ScalpelSpider() : base("Scalpel Spider", 3, 2000, Race.BrainJacker, Civilization.Darkness)
    {
        AddTriggeredAbility(new ScalpelSpiderAbility());
    }
}
