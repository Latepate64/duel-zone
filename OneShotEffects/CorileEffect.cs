using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class CorileEffect : CardMovingChoiceEffect<ICreature>
{
    public CorileEffect(CorileEffect effect) : base(effect)
    {
    }

    public CorileEffect() : base(1, 1, true, ZoneType.BattleZone, ZoneType.Deck)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new CorileEffect(this);
    }

    public override string ToString()
    {
        return "Choose one of your opponent's creatures in the battle zone and put it on top of his deck.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id);
    }
}
