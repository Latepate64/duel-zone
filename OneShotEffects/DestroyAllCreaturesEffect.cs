using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public class DestroyAllCreaturesEffect : DestroyAreaOfEffect
{
    public DestroyAllCreaturesEffect() : base()
    {
    }

    public DestroyAllCreaturesEffect(DestroyAreaOfEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new DestroyAllCreaturesEffect(this);
    }

    public override string ToString()
    {
        return "Destroy all creatures.";
    }

    protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.Creatures;
    }
}
