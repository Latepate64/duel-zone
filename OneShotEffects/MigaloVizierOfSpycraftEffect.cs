using Interfaces;

namespace OneShotEffects;

public sealed class MigaloVizierOfSpycraftEffect : LookEffect
{
    public MigaloVizierOfSpycraftEffect() : base(0, 2)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new MigaloVizierOfSpycraftEffect();
    }

    public override string ToString()
    {
        return "You may look at 2 of your opponent's shields. Then put them back where they were.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return GetOpponent(game).ShieldZone.Cards;
    }
}
