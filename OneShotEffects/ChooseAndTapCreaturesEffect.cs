using Interfaces;

namespace OneShotEffects;

public sealed class ChooseAndTapCreaturesEffect : TapChoiceEffect
{
    private readonly ICardFilter filter;

    public ChooseAndTapCreaturesEffect(
        int min, int max, ICardFilter filter) : base(min, max, true)
    {
        this.filter = filter;
    }

    public ChooseAndTapCreaturesEffect(
        ChooseAndTapCreaturesEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new ChooseAndTapCreaturesEffect(this);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreatures(Applier, filter, game);
    }
}
