using Engine.Abilities;
using Engine.GameEvents;
using Interfaces;

namespace Cards.DM12;

public sealed class NemonexAbility : TriggeredAbility
{
    public NemonexAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public NemonexAbility(NemonexAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is BecomeUnblockedEvent e && e.Attacker.Owner == Controller
            && e.Attacker.HasRace(Race.Xenoparts, Race.GiantInsect);
    }

    public override IAbility Copy()
    {
        return new NemonexAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever any of your Xeno Parts or Giant Insects is attacking and isn't blocked, {GetEffectText()}";
    }
}
