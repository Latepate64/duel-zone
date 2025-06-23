using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class SmileAngler : Creature
{
    public SmileAngler() : base("Smile Angler", 6, 3000, Race.GelFish, Civilization.Water)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new SmileAnglerEffect()));
    }
}
