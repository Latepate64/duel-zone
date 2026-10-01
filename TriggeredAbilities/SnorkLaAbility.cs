using Interfaces;

namespace TriggeredAbilities;

public sealed class SnorkLaAbility : LinkedTriggeredAbility
{
    private readonly ICard _card;

    public SnorkLaAbility() : base()
    {
    }

    public SnorkLaAbility(ICard card) : base()
    {
        _card = card;
    }

    public SnorkLaAbility(SnorkLaAbility ability) : base(ability)
    {
        _card = ability._card;
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IAbility Copy()
    {
        return new SnorkLaAbility(this);
    }

    public override void Resolve(IGame game)
    {
        if (Controller.ChooseToTakeAction(ToString()))
        {
            game.Move(this, ZoneType.Graveyard, ZoneType.ManaZone, _card);
        }
    }

    public override string ToString()
    {
        return "Whenever your opponent causes a card to be put into your graveyard from your mana zone, you may return that card to your mana zone.";
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        throw new NotImplementedException();
    }
}
