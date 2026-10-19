using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose 2 of your opponent's creatures in the battle zone. Your opponent
/// chooses one of them, puts it into his hand, and destroys the other one. Then
/// choose 2 cards in your opponent's mana zone. Your opponent chooses one of
/// them, puts it into his hand, and puts the other one into his graveyard.
/// </summary>
public sealed class MiraculousPlagueEffect : OneShotEffect
{
    private readonly ICardFilter filter;

    public MiraculousPlagueEffect(ICardFilter filter)
    {
        this.filter = filter;
    }

    public MiraculousPlagueEffect(MiraculousPlagueEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        var controller = Controller;
        var opponent = GetOpponent(game);

        var creatures = controller.ChooseCards(
            game.BattleZone.GetOpponentsChoosableCreatures(
                Applier, filter, game),
            2, 2, ToString());
        var toHand = opponent.ChooseCard(creatures, ToString());
        game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, toHand);
        game.Destroy(Ability, [.. creatures.Where(x => x != toHand)]);

        var cards = controller.ChooseCards(
            opponent.ManaZone.Cards, 2, 2, ToString());
        var manaToHand = opponent.ChooseCard(cards, ToString());
        game.Move(Ability, ZoneType.ManaZone, ZoneType.Hand, manaToHand);
        game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard,
            [.. cards.Where(x => x != manaToHand)]);
    }

    public override IOneShotEffect Copy()
    {
        return new MiraculousPlagueEffect(this);
    }
}
