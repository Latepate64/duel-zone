using Engine;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09;

public sealed class IceVaporShadowOfAnguish : Creature
{
    public IceVaporShadowOfAnguish() : base("Ice Vapor, Shadow of Anguish", 5, 1000, Race.Ghost, Civilization.Darkness)
    {
        AddTriggeredAbility(new WheneverYourOpponentCastsSpellAbility(new IceVaporShadowOfAnguishEffect()));
    }
}
