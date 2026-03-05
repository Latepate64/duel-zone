using Interfaces;

namespace OneShotEffects;

public sealed class ReapAndSowEffect : OneShotEffect
{
    public ReapAndSowEffect()
    {
    }

    public ReapAndSowEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var player = Controller;
        var card = player.ChooseCard(game.GetOpponent(player).ManaZone.Cards, ToString());
        game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, card);
        player.PutFromTopOfDeckIntoManaZone(game, 1, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new ReapAndSowEffect(this);
    }

    public override string ToString()
    {
        return "Choose a card in your opponent's mana zone and put it into his graveyard. Then put the top card of your deck into your mana zone.";
    }
}
