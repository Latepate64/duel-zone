using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM03;

public class RaVuSeekerOfLightning : Creature
{
    public RaVuSeekerOfLightning() : base("Ra Vu, Seeker of Lightning", 6, 4000, Race.MechaThunder, Civilization.Light)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new RaVuSeekerOfLightningEffect()));
    }
}
