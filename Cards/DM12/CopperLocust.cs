using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM12;

public sealed class CopperLocust : Creature
{
    public CopperLocust() : base("Copper Locust", 3, 5000, Race.GiantInsect, Civilization.Nature)
    {
        AddTriggeredAbility(new CopperLocustAbility(new DestroyThisCreatureEffect()));
    }
}
