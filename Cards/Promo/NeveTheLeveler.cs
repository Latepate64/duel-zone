using TriggeredAbilities;
using OneShotEffects;
using Interfaces;

namespace Cards.Promo;

public sealed class NeveTheLeveler : Creature
{
    public NeveTheLeveler() : base("Neve, the Leveler", 6, 4000, Race.SnowFaerie, Civilization.Nature)
    {
        AddTriggeredAbility(new NeveTheLevelerAbility(new NeveTheLevelerEffect()));
    }
}
