using Interfaces;

namespace OneShotEffects;

public sealed class ChooseAndReturnCreaturesToTheirOwnersHandsEffect
    : BounceEffect
{
    private readonly ICardFilter filter;

    public ChooseAndReturnCreaturesToTheirOwnersHandsEffect(
        int min, int max, ICardFilter filter) : base(min, max)
    {
        this.filter = filter;
    }

    public ChooseAndReturnCreaturesToTheirOwnersHandsEffect(
        ChooseAndReturnCreaturesToTheirOwnersHandsEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new ChooseAndReturnCreaturesToTheirOwnersHandsEffect(this);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreatures(Applier, filter, game);
    }
}
