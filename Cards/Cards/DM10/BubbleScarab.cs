using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System;

namespace Cards.Cards.DM10
{
    class BubbleScarab : Creature
    {
        public BubbleScarab() : base("Bubble Scarab", 5, 4000, Race.GiantInsect, Civilization.Nature)
        {
            AddTriggeredAbility(new BubbleScarabAbility());
        }
    }

    class BubbleScarabAbility : LinkedTriggeredAbility
    {
        private ICard _attackTarget;

        public BubbleScarabAbility()
        {
        }

        public BubbleScarabAbility(BubbleScarabAbility ability) : base(ability)
        {
            _attackTarget = ability._attackTarget;
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is CreatureAttackedEvent e && e.Target is ICard creature && creature.Owner == Controller;
        }

        public override IAbility Copy()
        {
            return new BubbleScarabAbility(this);
        }

        public override void Resolve(IGame game)
        {
            var card = Controller.ChooseCardOptionally(Controller.Hand.Cards, ToString());
            if (card != null)
            {
                Controller.Discard(this, card);
                game.AddContinuousEffects(this, new CreatureGetsPowerUntilTheEndOfTheTurnEffect(_attackTarget, 3000));
            }
        }

        public override string ToString()
        {
            return "Whenever one of your creatures is attacked, you may discard a card from your hand. If you do, that creature gets +3000 power until the end of the turn.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            _attackTarget = (gameEvent as CreatureAttackedEvent).Target as ICard;
            return new BubbleScarabAbility(this);
        }
    }

    class CreatureGetsPowerUntilTheEndOfTheTurnEffect : UntilEndOfTurnEffect, IPowerModifyingEffect
    {
        private readonly ICard _creature;
        private readonly int _power;

        public CreatureGetsPowerUntilTheEndOfTheTurnEffect(CreatureGetsPowerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            _creature = effect._creature;
            _power = effect._power;
        }

        public CreatureGetsPowerUntilTheEndOfTheTurnEffect(ICard creature, int power)
        {
            _creature = creature;
            _power = power;
        }

        public override IContinuousEffect Copy()
        {
            return new CreatureGetsPowerUntilTheEndOfTheTurnEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            _creature.Power += _power;
        }

        public override string ToString()
        {
            return $"{_creature} has +{_power} until the end of the turn.";
        }
    }
}
