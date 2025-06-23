using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class HydroozeTheMutantEmperorUnblockableEffect : ContinuousEffect, IUnblockableEffect
{
    public HydroozeTheMutantEmperorUnblockableEffect() : base()
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker, IAttackable targetOfAttack, IGame game)
    {
        return game.BattleZone.GetCreatures(Controller.Id).Contains(attacker)
            && (attacker.HasRace(Race.CyberLord) || attacker.HasRace(Race.Hedrian));
    }

    public override IContinuousEffect Copy()
    {
        return new HydroozeTheMutantEmperorUnblockableEffect();
    }

    public override string ToString()
    {
        return "Your Cyber Lords or Hedrians can't be blocked.";
    }
}
