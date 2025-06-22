using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM11
{
    sealed class LockdownLizard : Creature
    {
        public LockdownLizard() : base("Lockdown Lizard", 4, 3000, Race.MeltWarrior, Civilization.Fire)
        {
            AddStaticAbilities(new LockdownLizardEffect());
        }
    }

    sealed class LockdownLizardEffect : ContinuousEffect, IPlayersCannotUseTapAbilities
    {
        public LockdownLizardEffect()
        {
        }

        public LockdownLizardEffect(IContinuousEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new LockdownLizardEffect(this);
        }

        public override string ToString()
        {
            return "Players can't use the tap abilities of their creatures.";
        }
    }
}
