using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities;

public class AncientHornTheWatcherAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
{
    public AncientHornTheWatcherAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public AncientHornTheWatcherAbility(AncientHornTheWatcherAbility ability) : base(ability)
    {
    }

    public override IAbility Copy()
    {
        return new AncientHornTheWatcherAbility(this);
    }

    public override bool CheckInterveningIfClause(IGame game)
    {
        return Controller.ShieldZone.Size >= 5;
    }

    public override string ToString()
    {
        return $"When you put this creature into the battle zone, if you have 5 or more shields, {GetEffectText()}";
    }
}
