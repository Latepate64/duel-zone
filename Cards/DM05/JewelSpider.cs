using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM05;

public sealed class JewelSpider : Creature
{
    public JewelSpider() : base("Jewel Spider", 2, 1000, Race.BrainJacker, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(
            new YouMayChooseOneOfYourShieldsAndPutItIntoYourHandEffect()));
    }
}
