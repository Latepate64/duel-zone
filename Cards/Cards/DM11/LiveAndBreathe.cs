using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;
using System;
using System.Linq;

namespace Cards.Cards.DM11
{
    class LiveAndBreathe : Spell
    {
        public LiveAndBreathe() : base("Live and Breathe", 3, Civilization.Light, Civilization.Nature)
        {
            AddSpellAbilities(new LiveAndBreatheEffect());
        }
    }

    class LiveAndBreatheEffect : OneShotEffect
    {
        public LiveAndBreatheEffect()
        {
        }

        public LiveAndBreatheEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            Game.AddDelayedTriggeredAbility(new LiveAndBreatheDelayedAbility(Ability));
        }

        public override IOneShotEffect Copy()
        {
            return new LiveAndBreatheEffect(this);
        }

        public override string ToString()
        {
            return "Whenever you summon a creature this turn, search your deck. You may take a creature from your deck that has the same name as that creature and put it into the battle zone. Then shuffle your deck.";
        }
    }

    class LiveAndBreatheDelayedAbility : DelayedTriggeredAbility, IExpirable
    {
        public LiveAndBreatheDelayedAbility(IAbility ability) : base(new LiveAndBreatheAbility(), true, ability)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }
    }

    class LiveAndBreatheAbility : LinkedTriggeredAbility
    {
        private string _name;

        public LiveAndBreatheAbility()
        {
        }

        public LiveAndBreatheAbility(LiveAndBreatheAbility ability) : base(ability)
        {
            _name = ability._name;
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is CreatureSummonedEvent e && e.Player == Controller;
        }

        public override IAbility Copy()
        {
            return new LiveAndBreatheAbility(this);
        }

        public override void Resolve(IGame game)
        {
            var creature = Controller.ChooseCardOptionally(Controller.Deck.Creatures.Where(x => x.Name == _name), ToString());
            game.Move(this, ZoneType.Deck, ZoneType.BattleZone, creature);
            Controller.ShuffleOwnDeck();
        }

        public override string ToString()
        {
            return "Whenever you summon a creature, search your deck. You may take a creature from your deck that has the same name as that creature and put it into the battle zone. Then shuffle your deck.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            _name = (gameEvent as CreatureSummonedEvent).Creature.Name;
            return new LiveAndBreatheAbility(this);
        }
    }
}
