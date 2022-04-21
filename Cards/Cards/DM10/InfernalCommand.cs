using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;

namespace Cards.Cards.DM10
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
        public override void Apply(IGame game, IAbility source)
        {
            var creature = GetController(game).ChooseOpponentsCreature(game, ToString());
            game.AddContinuousEffects(source, new InfernalCommandContinuousEffect(creature));
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
        private readonly ICard _creature;

        public InfernalCommandContinuousEffect(ICard creature)
        {
            _creature = creature;
        }

        public InfernalCommandContinuousEffect(InfernalCommandContinuousEffect effect) : base(effect)
        {
            _creature = effect._creature;
        }

        public bool AttacksIfAble(ICard creature, IGame game)
        {
            return creature == _creature;
        }

        public override IContinuousEffect Copy()
        {
            return new InfernalCommandContinuousEffect(this);
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.StartOfTurn && phase.Turn.ActivePlayer == GetController(game);
        }

        public override string ToString()
        {
            return $"{_creature} attacks if able until the start of your next turn.";
        }
    }
}
