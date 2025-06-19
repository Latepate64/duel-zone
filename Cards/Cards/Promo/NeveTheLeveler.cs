using Abilities.Triggered;
using Effects.OneShot;
using Engine;

namespace Cards.Cards.Promo;

public class NeveTheLeveler : Creature
{
    public NeveTheLeveler() : base("Neve, the Leveler", 6, 4000, Race.SnowFaerie, Civilization.Nature)
    {
        AddTriggeredAbility(new NeveTheLevelerAbility(new NeveTheLevelerEffect()));
    }
}
