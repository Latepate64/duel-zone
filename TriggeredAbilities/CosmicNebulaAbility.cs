using Engine.Abilities;
using Engine.GameEvents;
using Interfaces;

namespace TriggeredAbilities;

public sealed class CosmicNebulaAbility : TriggeredAbility
{
    public CosmicNebulaAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public CosmicNebulaAbility(CosmicNebulaAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent e && e.Phase.Type == Engine.Steps.PhaseOrStep.Draw
            && e.Turn.ActivePlayer == Controller;
    }

    public override IAbility Copy()
    {
        return new CosmicNebulaAbility(this);
    }

    public override string ToString()
    {
        return "Whenever you draw the card at the start of your turn, you may draw an extra card.";
    }
}
