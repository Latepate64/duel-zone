using Cards.TriggeredAbilities;
using Engine;
using Engine.GameEvents;

namespace Cards.Cards.DM10
{
    class SmashWarriorStagrandu : Creature
    {
        public SmashWarriorStagrandu() : base("Smash Warrior Stagrandu", 2, 1000, Race.Armorloid, Civilization.Fire)
        {
            AddThisCreatureCanAttackUntappedCreaturesAbility();
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
            return base.CanTrigger(gameEvent, game) && gameEvent is CreatureAttackedEvent e && e.Target is ICard c && c.Power >= 6000;
        }
    }
}
