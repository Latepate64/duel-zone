using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;
using System.Linq;

namespace Cards.Cards.DM05
{
    class MiracleQuest : Spell
    {
        public MiracleQuest() : base("Miracle Quest", 3, Civilization.Water)
        {
            AddSpellAbilities(new MiracleQuestEffect());
        }
    }

    class MiracleQuestEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddDelayedTriggeredAbility(new MiracleQuestDelayedTriggeredAbility(source));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new MiracleQuestEffect();
        }

        public override string ToString()
        {
            return "Whenever any of your creatures finishes attacking this turn, you may draw 2 cards for each shield it broke.";
        }
    }

    class MiracleQuestDelayedTriggeredAbility : DelayedTriggeredAbility, IExpirable
    {
        public MiracleQuestDelayedTriggeredAbility(IAbility source) : base(new WheneverAnyOfYourCreaturesFinishesAttackingAbility(), source.Source, source.Controller, false)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }
    }

    class WheneverAnyOfYourCreaturesFinishesAttackingAbility : TriggeredAbility
    {
        public WheneverAnyOfYourCreaturesFinishesAttackingAbility() : base(new MiracleQuestDrawEffect())
        {
        }

        public WheneverAnyOfYourCreaturesFinishesAttackingAbility(WheneverAnyOfYourCreaturesFinishesAttackingAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is CreatureStoppedAttackingEvent e && e.AttackingCreature.Id == GetController(game).Id;
        }

        public override IAbility Copy()
        {
            return new WheneverAnyOfYourCreaturesFinishesAttackingAbility(this);
        }

        public override string ToString()
        {
            return "Whenever any of your creatures finishes attacking, you may draw 2 cards for each shield it broke.";
        }
    }

    class MiracleQuestDrawEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var attacker = game.GetCard(source.Source);
            // TODO: Should retrieve amount based on the actual attack, now calculates all attacks by attacker (in rare cases could be more than one attack)
            var amount = game.CurrentTurn.GameEvents.OfType<BreakShieldsEvent>().Where(x => x.Attacker == attacker).Sum(x => x.BreakAmount);
            for (int i = 0; i < amount; ++i)
            {
                if (source.GetController(game).ChooseToTakeAction("You may draw 2 cards."))
                {
                    source.GetController(game).DrawCards(2, game, source);
                }
                else
                {
                    break;
                }
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new MiracleQuestDrawEffect();
        }

        public override string ToString()
        {
            return "You may draw 2 cards for each shield it broke.";
        }
    }
}
