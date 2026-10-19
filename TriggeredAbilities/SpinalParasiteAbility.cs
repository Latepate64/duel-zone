using Interfaces;
using Interfaces.ContinuousEffects;

namespace TriggeredAbilities;

/// <summary>
/// At the start of each of your opponent's turns, he chooses one of his
/// creatures in the battle zone that can attack. That creature attacks that
/// turn if able.
/// </summary>
public sealed class SpinalParasiteAbility : LinkedTriggeredAbility
{
    private readonly IPlayer? player;
    private readonly IContinuousEffectFactory factory;

    public SpinalParasiteAbility(IContinuousEffectFactory factory)
    {
        this.factory = factory;
    }

    public SpinalParasiteAbility(SpinalParasiteAbility ability) : base(ability)
    {
        factory = ability.factory;
        player = ability.player;
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
        // return gameEvent is PhaseBegunEvent e && e.Phase.Type == GameEvents.Steps.PhaseOrStep.StartOfTurn
        //     && e.Turn.ActivePlayer == GetOpponent(game);
    }

    public override IAbility Copy()
    {
        return new SpinalParasiteAbility(this);
    }

    public override void Resolve(IGame game)
    {
        if (player == null) return;
        var creatures = game.BattleZone.GetCreatures(player.Id).Where(
        x => game.CanAttackAtLeastSomething(x));
        var creature = (ICreature)player.ChooseCard(creatures, this.ToString());
        game.AddContinuousEffects(
            this,
            factory.Create(creature));
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        throw new NotImplementedException();
        // _player = (gameEvent as PhaseBegunEvent).Turn.ActivePlayer;
        // return new SpinalParasiteAbility(this);
    }
}
