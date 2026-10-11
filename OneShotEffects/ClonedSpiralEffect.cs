using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose a creature in battle zone. Then, for each card name in each
/// graveyard, you may choose another creature in the battle zone. Return all
/// those creature to their owner's hands.
/// </summary>
public sealed class ClonedSpiralEffect : ClonedEffect
{
    private readonly ICardFilter filter;

    public ClonedSpiralEffect(string name, ICardFilter filter) : base(name)
    {
        this.filter = filter;
    }

    public ClonedSpiralEffect(ClonedSpiralEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        var creatures = Controller.ChooseCards(
            game.BattleZone.GetChoosableCreatures(Applier, filter, game),
            1, GetAmount(game), ToString());
        game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, [.. creatures]);
    }

    public override IOneShotEffect Copy()
    {
        return new ClonedSpiralEffect(this);
    }
}
