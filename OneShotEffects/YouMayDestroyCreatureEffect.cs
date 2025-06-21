using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public class YouMayDestroyCreatureEffect : DestroyEffect
{
    public YouMayDestroyCreatureEffect() : base(0, 1, true)
    {
    }

    public YouMayDestroyCreatureEffect(DestroyEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayDestroyCreatureEffect(this);
    }

    public override string ToString()
    {
        return "You may destroy a creature.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByAnyone(game, GetOpponent(game).Id);
    }
}
