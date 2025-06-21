using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Interfaces;
using Interfaces.ContinuousEffects;
using System;

namespace Cards.DM10
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
        private Creature _attackTarget;

        public BubbleScarabAbility()
        {
        }

        public BubbleScarabAbility(BubbleScarabAbility ability) : base(ability)
        {
            _attackTarget = ability._attackTarget;
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is CreatureAttackedEvent e && e.Target is ICreature creature && creature.Owner == Controller;
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
                Controller.Discard(this, game, card);
                game.AddContinuousEffects(this, new CreatureGetsPowerUntilTheEndOfTheTurnEffect(_attackTarget, 3000));
            }
        }

        public override string ToString()
        {
            return "Whenever one of your creatures is attacked, you may discard a card from your hand. If you do, that creature gets +3000 power until the end of the turn.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            _attackTarget = (gameEvent as CreatureAttackedEvent).Target as Creature;
            return new BubbleScarabAbility(this);
        }
    }

    class CreatureGetsPowerUntilTheEndOfTheTurnEffect : UntilEndOfTurnEffect, IPowerModifyingEffect
    {
        private readonly ICreature _creature;
        private readonly int _power;

        public CreatureGetsPowerUntilTheEndOfTheTurnEffect(CreatureGetsPowerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            _creature = effect._creature;
            _power = effect._power;
        }

        public CreatureGetsPowerUntilTheEndOfTheTurnEffect(ICreature creature, int power)
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
            _creature.IncreasePower(_power);
        }

        public override string ToString()
        {
            return $"{_creature} has +{_power} until the end of the turn.";
        }
    }
}
