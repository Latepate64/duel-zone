using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class KingNeptasEffect : BounceEffect
{
    public KingNeptasEffect() : base(0, 1)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new KingNeptasEffect();
    }

    public override string ToString()
    {
        return "You may choose a creature in the battle zone that has power 2000 or less and return it to its owner's hand.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByAnyone(game, GetOpponent(game).Id).Where(
            x => x.Power <= 2000);
    }
}
