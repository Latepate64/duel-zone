using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose one of your opponent's creatures in the battle zone and put the top
/// card of that creature into your opponent's mana zone.
/// </summary>
public sealed class PutTopCardOfOpponentsCreatureIntoTheirManaZoneEffect
    : OneShotEffect
{
    private readonly ICardFilter filter;

    public PutTopCardOfOpponentsCreatureIntoTheirManaZoneEffect(
        ICardFilter filter)
    {
        this.filter = filter;
    }

    public PutTopCardOfOpponentsCreatureIntoTheirManaZoneEffect(
        PutTopCardOfOpponentsCreatureIntoTheirManaZoneEffect effect) : base(
            effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetOpponentsChoosableCreatures(
            Applier, filter, game);
        var card = Controller.ChooseCard(creatures, ToString());
        if (card != null)
        {
            game.MoveTopCard(card, ZoneType.ManaZone, Ability);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new PutTopCardOfOpponentsCreatureIntoTheirManaZoneEffect(this);
    }
}
