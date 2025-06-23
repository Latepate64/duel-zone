using Engine.Abilities;
using Engine.GameEvents;
using Interfaces;
using System;
using System.Linq;

namespace Cards.DM10;

public sealed class SpinalParasiteAbility : LinkedTriggeredAbility
{
    private IPlayer _player;

    public SpinalParasiteAbility()
    {
    }

    public SpinalParasiteAbility(SpinalParasiteAbility ability) : base(ability)
    {
        _player = ability._player;
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent e && e.Phase.Type == Engine.Steps.PhaseOrStep.StartOfTurn
            && e.Turn.ActivePlayer == GetOpponent(game);
    }

    public override IAbility Copy()
    {
        return new SpinalParasiteAbility(this);
    }

    public override void Resolve(IGame game)
    {
        var creature = _player.ChooseCard(game.BattleZone.GetCreatures(_player.Id).Where(
            x => game.CanAttackAtLeastSomething(x)), ToString()) as ICreature;
        game.AddContinuousEffects(this, new SpinalParasiteContinuousEffect(creature));
    }

    public override string ToString()
    {
        return "At the start of each of your opponent's turns, he chooses one of his creatures in the battle zone that can attack. That creature attacks that turn if able.";
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        _player = (gameEvent as PhaseBegunEvent).Turn.ActivePlayer;
        return new SpinalParasiteAbility(this);
    }
}
