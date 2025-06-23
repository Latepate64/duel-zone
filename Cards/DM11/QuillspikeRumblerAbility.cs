using TriggeredAbilities;
using Engine;
using Engine.GameEvents;
using Interfaces;
using Engine.Abilities;

namespace Cards.DM11;

public sealed class QuillspikeRumblerAbility : WheneverThisCreatureAttacksAbility
{
    public QuillspikeRumblerAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public QuillspikeRumblerAbility(WheneverThisCreatureAttacksAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return base.CanTrigger(gameEvent, game) && gameEvent is CreatureAttackedEvent e && e.Target is Card;
    }

    public override string ToString()
    {
        return $"Whenever this creature attacks a creature, {GetEffectText()}";
    }
}
