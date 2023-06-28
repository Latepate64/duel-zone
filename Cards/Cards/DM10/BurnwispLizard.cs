using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM10
{
    class BurnwispLizard : Creature
    {
        public BurnwispLizard() : base("Burnwisp Lizard", 5, 4000, Race.MeltWarrior, Civilization.Fire)
        {
            AddStaticAbilities(new BurnwispLizardEffect());
        }
    }

    class BurnwispLizardEffect : ContinuousEffect, ISpeedAttackerEffect
    {
        public BurnwispLizardEffect() : base()
        {
        }

        public bool Applies(ICard creature)
        {
            return creature.Owner == Applier && creature.GetAbilities<Engine.Abilities.SilentSkillAbility>().Any();
        }

        public override IContinuousEffect Copy()
        {
            return new BurnwispLizardEffect();
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone that has \"silent skill\" has \"speed attacker.\"";
        }
    }
}
