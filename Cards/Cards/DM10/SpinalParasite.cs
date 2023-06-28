using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System;
using System.Linq;

namespace Cards.Cards.DM10
{
    class SpinalParasite : Creature
    {
        public SpinalParasite() : base("Spinal Parasite", 5, 2000, Race.BrainJacker, Civilization.Darkness)
        {
            AddTriggeredAbility(new SpinalParasiteAbility());
        }
    }

    class SpinalParasiteAbility : LinkedTriggeredAbility
    {
        private IPlayer _player;

        public SpinalParasiteAbility()
        {
        }

        public SpinalParasiteAbility(SpinalParasiteAbility ability) : base(ability)
        {
            _player = ability._player;
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent e && e.Phase.Type == Engine.Steps.PhaseOrStep.StartOfTurn && e.Turn.ActivePlayer == Controller.Opponent;
        }

        public override IAbility Copy()
        {
            return new SpinalParasiteAbility(this);
        }

        public override void Resolve(IGame game)
        {
            var creature = _player.ChooseCard(game.BattleZone.GetCreatures(_player.Id).Where(x => game.CanAttackAtLeastSomething(x)), ToString());
            game.AddContinuousEffects(this, new SpinalParasiteContinuousEffect(creature));
        }

        public override string ToString()
        {
            return "At the start of each of your opponent's turns, he chooses one of his creatures in the battle zone that can attack. That creature attacks that turn if able.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            _player = (gameEvent as PhaseBegunEvent).Turn.ActivePlayer;
            return new SpinalParasiteAbility(this);
        }
    }

    class SpinalParasiteContinuousEffect : UntilEndOfTurnEffect, IAttacksIfAbleEffect
    {
        private readonly ICard _creature;

        public SpinalParasiteContinuousEffect(ICard creature)
        {
            _creature = creature;
        }

        public SpinalParasiteContinuousEffect(SpinalParasiteContinuousEffect effect) : base(effect)
        {
            _creature = effect._creature;
        }

        public bool AttacksIfAble(ICard creature, IGame game)
        {
            return creature == _creature;
        }

        public override IContinuousEffect Copy()
        {
            return new SpinalParasiteContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"{_creature} attacks this turn if able.";
        }
    }
}
