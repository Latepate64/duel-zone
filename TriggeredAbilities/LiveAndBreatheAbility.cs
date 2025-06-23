using Engine.Abilities;
using Engine.GameEvents;
using System;
using System.Linq;
using Interfaces;

namespace TriggeredAbilities;

public sealed class LiveAndBreatheAbility : LinkedTriggeredAbility
{
    private string _name;

    public LiveAndBreatheAbility()
    {
    }

    public LiveAndBreatheAbility(LiveAndBreatheAbility ability) : base(ability)
    {
        _name = ability._name;
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is CreatureSummonedEvent e && e.Player == Controller;
    }

    public override IAbility Copy()
    {
        return new LiveAndBreatheAbility(this);
    }

    public override void Resolve(IGame game)
    {
        var creature = Controller.ChooseCardOptionally(
            Controller.Deck.Creatures.Where(x => x.Name == _name), ToString());
        game.Move(this, ZoneType.Deck, ZoneType.BattleZone, creature);
        Controller.ShuffleOwnDeck(game);
    }

    public override string ToString()
    {
        return "Whenever you summon a creature, search your deck. You may take a creature from your deck that has the same name as that creature and put it into the battle zone. Then shuffle your deck.";
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        _name = (gameEvent as CreatureSummonedEvent).Creature.Name;
        return new LiveAndBreatheAbility(this);
    }
}
