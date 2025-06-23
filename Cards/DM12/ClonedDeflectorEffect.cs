using OneShotEffects;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM12;

public sealed class ClonedDeflectorEffect : ClonedEffect
{
    public ClonedDeflectorEffect(string name) : base(name)
    {
    }

    public ClonedDeflectorEffect(ClonedDeflectorEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var player = Controller;
        var creatures = player.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByPlayer(
            game, GetOpponent(game).Id), 1, GetAmount(game), ToString());
        player.Tap(game, [.. creatures]);
    }

    public override IOneShotEffect Copy()
    {
        return new ClonedDeflectorEffect(this);
    }

    public override string ToString()
    {
        return $"Choose one of your opponent's creatures in the battle zone. Then, for each {_name} in each graveyard, you may choose another of your opponent's creatures in the battle zone. Tap all those creatures.";
    }
}
