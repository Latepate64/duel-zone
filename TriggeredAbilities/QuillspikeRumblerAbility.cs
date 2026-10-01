using Interfaces;

namespace TriggeredAbilities;

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
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"Whenever this creature attacks a creature, {GetEffectText()}";
    }
}
