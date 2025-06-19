using Abilities.Triggered;
using Effects.Continuous;
using Engine;
using Engine.GameEvents;

namespace Cards.Cards.DM10
{
    class SmashWarriorStagrandu : Creature
    {
        public SmashWarriorStagrandu() : base("Smash Warrior Stagrandu", 2, 1000, Race.Armorloid, Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
            AddTriggeredAbility(new StagranduAbility());
        }
    }

    class StagranduAbility : WheneverThisCreatureAttacksAbility
    {
        public StagranduAbility() : base(new OneShotEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(9000))
        {
        }

        public StagranduAbility(StagranduAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is CreatureAttackedEvent e
                && e.Target is Creature c && c.Power >= 6000;
        }
    }
}
