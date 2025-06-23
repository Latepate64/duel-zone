using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM11;

public sealed class LockdownLizard : Creature
{
    public LockdownLizard() : base("Lockdown Lizard", 4, 3000, Race.MeltWarrior, Civilization.Fire)
    {
        AddStaticAbilities(new LockdownLizardEffect());
    }
}
