using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class BallusDogfightEnforcerQ : Creature
    {
        public BallusDogfightEnforcerQ() : base("Ballus, Dogfight Enforcer Q", 5, 3000, Civilization.Light)
        {
            AddSubtypes(Subtype.Survivor, Subtype.Berserker);
            AddAbilities(new StaticAbilities.SurvivorAbility(new TriggeredAbilities.AtTheEndOfYourTurnAbility(new UntapThisCreatureEffect())));
        }
    }

    class UntapThisCreatureEffect : OneShotEffects.UntapAreaOfEffect
    {
        public UntapThisCreatureEffect() : base(new TargetFilter()) { }

        public override IOneShotEffect Copy()
        {
            return new UntapThisCreatureEffect();
        }

        public override string ToString()
        {
            return "Untap this creature.";
        }
    }
}
