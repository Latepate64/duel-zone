using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM11
{
    class LockdownLizard : Creature
    {
        public LockdownLizard() : base("Lockdown Lizard", 4, 3000, Race.MeltWarrior, Civilization.Fire)
        {
            AddStaticAbilities(new LockdownLizardEffect());
        }
    }

    class LockdownLizardEffect : ContinuousEffect, IPlayersCannotUseTapAbilities
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
