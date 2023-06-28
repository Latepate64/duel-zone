using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;
using System;
using System.Linq;

namespace Cards.Cards.DM09
{
    class FistsOfForever : Spell
    {
        public FistsOfForever() : base("Fists of Forever", 1, Civilization.Fire)
        {
            AddSpellAbilities(new FistsOfForeverEffect());
        }
    }

    class FistsOfForeverEffect : OneShotEffect
    {
        public FistsOfForeverEffect()
        {
        }

        public FistsOfForeverEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var creature = Applier.ChooseControlledCreature(game, ToString());
            game.AddDelayedTriggeredAbility(new FistsOfForeverDelayedTriggeredAbility(creature, Ability));
        }

        public override IOneShotEffect Copy()
        {
            return new FistsOfForeverEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your creatures in the battle zone. Whenever that creature wins a battle this turn, untap it.";
        }
    }

    class FistsOfForeverDelayedTriggeredAbility : DelayedTriggeredAbility, IExpirable
    {
        public FistsOfForeverDelayedTriggeredAbility(ICard creature, IAbility source) : base(new FistsOfForeverAbility(creature), false, source)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }
    }

    class FistsOfForeverAbility : LinkedTriggeredAbility
    {
        private readonly ICard _creature;

        public FistsOfForeverAbility(ICard creature)
        {
            _creature = creature;
        }

        public FistsOfForeverAbility(FistsOfForeverAbility ability) : base(ability)
        {
            _creature = ability._creature;
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is BattleEvent e && e.Winners.Contains(_creature);
        }

        public override IAbility Copy()
        {
            return new FistsOfForeverAbility(this);
        }

        public override void Resolve(IGame game)
        {
            Controller.Untap(game, _creature);
        }

        public override string ToString()
        {
            return $"Whenever {_creature} wins a battle this turn, untap it.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            return new FistsOfForeverAbility(this);
        }
    }
}
