using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM04;

public class SmileAngler : Creature
{
    public SmileAngler() : base("Smile Angler", 6, 3000, Race.GelFish, Civilization.Water)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new SmileAnglerEffect()));
    }
}
