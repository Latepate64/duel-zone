using Engine;
using Interfaces;

namespace Cards.DM09;

public class IceVaporShadowOfAnguish : Creature
{
    public IceVaporShadowOfAnguish() : base("Ice Vapor, Shadow of Anguish", 5, 1000, Race.Ghost, Civilization.Darkness)
    {
        AddTriggeredAbility(new WheneverYourOpponentCastsSpellAbility(new IceVaporShadowOfAnguishEffect()));
    }
}
