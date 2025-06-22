using Engine.Abilities;
using Engine.GameEvents;
using System;
using Interfaces;

namespace Cards.DM11;

public sealed class SlashAndBurnAbility : LinkedTriggeredAbility
{
    public SlashAndBurnAbility()
    {
    }

    public SlashAndBurnAbility(LinkedTriggeredAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is CardMovedEvent e && e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard
            && e.CardInDestinationZone.Owner == GetOpponent(game);
    }

    public override IAbility Copy()
    {
        return new SlashAndBurnAbility(this);
    }

    public override void Resolve(IGame game)
    {
        var opponent = GetOpponent(game);
        opponent.BurnOwnMana(game, this);
        var shield = opponent.ChooseCard(opponent.ShieldZone.Cards, ToString());
        game.Move(this, ZoneType.ShieldZone, ZoneType.Graveyard, shield);
    }

    public override string ToString()
    {
        return "Whenever any of your opponent's creatures is destroyed, your opponent chooses a card in his mana zone and puts it into his graveyard. Then he chooses one of his shields and puts it into his graveyard.";
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        return Copy() as ITriggeredAbility;
    }
}
