using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class YourLightCreaturesCannotBeBlockedThisTurnEffect : UntilEndOfTurnEffect, IUnblockableEffect
{
    public YourLightCreaturesCannotBeBlockedThisTurnEffect() : base()
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker, IAttackable targetOfAttack, IGame game)
    {
        return game.BattleZone.GetCreatures(Controller.Id).Contains(attacker) && attacker.HasCivilization(
            Civilization.Light);
    }

    public override IContinuousEffect Copy()
    {
        return new YourLightCreaturesCannotBeBlockedThisTurnEffect();
    }

    public override string ToString()
    {
        return "Your light creatures can't be blocked this turn.";
    }
}
