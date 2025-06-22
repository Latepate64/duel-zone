using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM10
{
    sealed class BurnwispLizard : Creature
    {
        public BurnwispLizard() : base("Burnwisp Lizard", 5, 4000, Race.MeltWarrior, Civilization.Fire)
        {
            AddStaticAbilities(new BurnwispLizardEffect());
        }
    }

    sealed class BurnwispLizardEffect : ContinuousEffect, ISpeedAttackerEffect
    {
        public BurnwispLizardEffect() : base()
        {
        }

        public bool Applies(ICreature creature, IGame game)
        {
            return creature.Owner == Controller && creature.GetAbilities<Engine.Abilities.SilentSkillAbility>().Any();
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
