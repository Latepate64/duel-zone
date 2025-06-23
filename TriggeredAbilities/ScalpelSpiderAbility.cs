using Engine.GameEvents;
using Interfaces;
using ContinuousEffects;

namespace TriggeredAbilities;

public sealed class ScalpelSpiderAbility : LinkedTriggeredAbility
{
    public ScalpelSpiderAbility() : base()
    {
    }

    public ScalpelSpiderAbility(ScalpelSpiderAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is CreatureAttackedEvent e && e.Target == Source;
    }

    public override IAbility Copy()
    {
        return new ScalpelSpiderAbility(this);
    }

    public override string ToString()
    {
        return "Whenever this creature is attacked, it gets \"slayer\" until the end of the turn.";
    }

    public override void Resolve(IGame game)
    {
        game.AddContinuousEffects(this, new CreatureGetsSlayerUntilEndOfTheTurnEffect(Source));
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        return new ScalpelSpiderAbility(this);
    }
}
