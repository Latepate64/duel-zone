using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM10
{
    class InfernalCommand : Spell
    {
        public InfernalCommand() : base("Infernal Command", 1, Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new InfernalCommandEffect());
        }
    }

    class InfernalCommandEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var creature = Controller.ChooseOpponentsCreature(game, ToString());
            game.AddContinuousEffects(Ability, new InfernalCommandContinuousEffect(creature));
        }

        public override IOneShotEffect Copy()
        {
            return new InfernalCommandEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's creatures in the battle zone. It gets \"this creature attacks if able\" until the start of your next turn.";
        }
    }

    class InfernalCommandContinuousEffect : ContinuousEffect, IAttacksIfAbleEffect, IExpirable
    {
        private readonly ICreature _creature;

        public InfernalCommandContinuousEffect(ICreature creature)
        {
            _creature = creature;
        }

        public InfernalCommandContinuousEffect(InfernalCommandContinuousEffect effect) : base(effect)
        {
            _creature = effect._creature;
        }

        public bool AttacksIfAble(ICreature creature, IGame game)
        {
            return creature == _creature;
        }

        public override IContinuousEffect Copy()
        {
            return new InfernalCommandContinuousEffect(this);
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.StartOfTurn && phase.Turn.ActivePlayer == Controller;
        }

        public override string ToString()
        {
            return $"{_creature} attacks if able until the start of your next turn.";
        }
    }
}
