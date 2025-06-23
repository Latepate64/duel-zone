using Engine.Abilities;
using Engine.GameEvents;
using Interfaces;

namespace TriggeredAbilities;

public sealed class WarpedLunatronAbility : LinkedTriggeredAbility
{
    private IPlayer _player;

    public WarpedLunatronAbility()
    {
    }

    public WarpedLunatronAbility(WarpedLunatronAbility ability) : base(ability)
    {
        _player = ability._player;
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent e && e.Phase.Type == Engine.Steps.PhaseOrStep.StartOfTurn; //TODO: Not sure if works as is 
    }

    public override IAbility Copy()
    {
        return new WarpedLunatronAbility(this);
    }

    public override void Resolve(IGame game)
    {
        var cards = _player.ChooseAnyNumberOfCards(_player.ManaZone.UntappedCards, ToString());
        var amount = cards.Count() / 2;
        var toUntap = _player.ChooseCards(game.BattleZone.GetCreatures(_player.Id), amount, amount, ToString());
        _player.Untap(game, [.. toUntap]);
    }

    public override string ToString()
    {
        return "When each player untaps his cards at the start of his turn, he may then tap any number of cards in his mana zone. For every 2 cards he taps this way, he untaps one of his creatures in the battle zone.";
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        _player = (gameEvent as PhaseBegunEvent).Turn.ActivePlayer;
        return Copy() as ITriggeredAbility;
    }
}
