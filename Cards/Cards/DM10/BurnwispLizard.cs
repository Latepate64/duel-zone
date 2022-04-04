using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM10
{
    class BurnwispLizard : Creature
    {
        public BurnwispLizard() : base("Burnwisp Lizard", 5, 4000, Subtype.MeltWarrior, Civilization.Fire)
        {
            AddStaticAbilities(new BurnwispLizardEffect());
        }
    }

    class BurnwispLizardEffect : ContinuousEffect, ISpeedAttackerEffect
    {
        public BurnwispLizardEffect() : base(new CardFilters.OwnersBattleZoneSilentSkillCreatureFilter(), new Durations.Indefinite())
        {
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
