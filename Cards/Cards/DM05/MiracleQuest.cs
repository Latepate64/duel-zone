﻿using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;
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
        public MiracleQuestEffect()
        {
        }

        public MiracleQuestEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.AddDelayedTriggeredAbility(new WheneverSomethingHappensThisTurnAbility(new WheneverAnyOfYourCreaturesFinishesAttackingAbility(), Ability));
        }

        public override IOneShotEffect Copy()
        {
            return new MiracleQuestEffect(this);
        }

        public override string ToString()
        {
            return "Whenever any of your creatures finishes attacking this turn, you may draw 2 cards for each shield it broke.";
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
            return gameEvent is CreatureStoppedAttackingEvent e && e.AttackingCreature.Owner == Controller;
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
        public MiracleQuestDrawEffect()
        {
        }

        public MiracleQuestDrawEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            // TODO: Should retrieve amount based on the actual attack, now calculates all attacks by attacker (in rare cases could be more than one attack)
            var amount = game.CurrentTurn.GameEvents.OfType<CreatureBreaksShieldsEvent>().Where(x => x.Attacker == Ability.Source).Sum(x => x.BreakAmount);
            for (int i = 0; i < amount; ++i)
            {
                if (Controller.ChooseToTakeAction("You may draw 2 cards."))
                {
                    Controller.DrawCards(2, game, Ability);
                }
                else
                {
                    break;
                }
            }
        }

        public override IOneShotEffect Copy()
        {
            return new MiracleQuestDrawEffect(this);
        }

        public override string ToString()
        {
            return "You may draw 2 cards for each shield it broke.";
        }
    }
}
