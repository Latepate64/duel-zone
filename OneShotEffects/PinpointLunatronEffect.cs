using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class PinpointLunatronEffect : CardSelectionEffect<ICard>
{
    public PinpointLunatronEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new PinpointLunatronEffect();
    }

    public override string ToString()
    {
        return "Choose a creature in the battle zone or a card in either player's mana zone and return it to its owner's hand.";
    }

    protected override void Apply(IGame game, IAbility source, params ICard[] cards)
    {
        foreach (var card in cards)
        {
            var sourceZone = game.BattleZone.Cards.Contains(card) ? ZoneType.BattleZone : ZoneType.ManaZone;
            game.Move(Ability, sourceZone, ZoneType.Hand, card);
        }
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return game.Players.SelectMany(x => x.ManaZone.Cards).Union(
            game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id)).Union(
                game.BattleZone.GetCreatures(Ability.Controller.Id));
    }
}
