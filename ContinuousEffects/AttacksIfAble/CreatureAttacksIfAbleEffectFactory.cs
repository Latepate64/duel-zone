using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AttacksIfAble;

public class CreatureAttacksIfAbleEffectFactory : IContinuousEffectFactory
{
    public IContinuousEffect Create(params ICreature[] creatures)
    {
        return new CreatureAttacksIfAbleEffect(creatures.Single());
    }
}