using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose an opponent's creature in the battle zone. Then, for each card name
/// in each graveyard, you may choose another opponent's creature in the battle
/// zone. Destroy all those creatures.
/// </summary>
public sealed class ClonedBladeEffect : ClonedEffect
{
    private readonly ICardFilter filter;

    public ClonedBladeEffect(string name, ICardFilter filter) : base(name)
    {
        this.filter = filter;
    }

    public ClonedBladeEffect(ClonedBladeEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        var enumerable = game.BattleZone.GetOpponentsChoosableCreatures(
            Applier, filter, game);
        var creatures = Controller.ChooseCards(
            enumerable, 1, GetAmount(game), ToString());
        game.Destroy(Ability, [.. creatures]);
    }

    public override IOneShotEffect Copy()
    {
        return new ClonedBladeEffect(this);
    }
}
