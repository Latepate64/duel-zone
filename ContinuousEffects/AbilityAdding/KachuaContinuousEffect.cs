using Abilities.Static;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// That creature has "speed attacker."
/// </summary>
public sealed class KachuaContinuousEffect : ContinuousEffect,
    IAbilityAddingEffect
{
    public KachuaContinuousEffect(ICreature creature)
    {
        Creature = creature;
    }

    public KachuaContinuousEffect(KachuaContinuousEffect effect) : base(effect)
    {
        Creature = (ICreature)effect.Creature.Copy();
    }

    public ICreature Creature { get; }

    public void AddAbility(IGame game)
    {
        game.AddAbility(Creature, new SpeedAttackerAbility());
    }

    public override IContinuousEffect Copy()
    {
        return new KachuaContinuousEffect(this);
    }
}
