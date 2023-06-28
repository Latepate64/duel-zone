using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;

namespace Cards.Cards.DM05
{
    class SlimeVeil : Spell
    {
        public SlimeVeil() : base("Slime Veil", 1, Civilization.Darkness)
        {
            AddSpellAbilities(new SlimeVeilOneShotEffect());
        }
    }

    class SlimeVeilOneShotEffect : OneShotEffect
    {
        public SlimeVeilOneShotEffect()
        {
        }

        public SlimeVeilOneShotEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Ability, new SlimeVeilContinuousEffect(Applier.Opponent));
        }

        public override IOneShotEffect Copy()
        {
            return new SlimeVeilOneShotEffect(this);
        }

        public override string ToString()
        {
            return "During your opponent's next turn, each of his creatures attacks if able.";
        }
    }

    class SlimeVeilContinuousEffect : ContinuousEffect, IAttacksIfAbleEffect, IExpirable
    {
        private readonly IPlayer _player;

        public SlimeVeilContinuousEffect(IPlayer player)
        {
            _player = player;
        }

        public SlimeVeilContinuousEffect(SlimeVeilContinuousEffect effect) : base(effect)
        {
            _player = effect._player;
        }

        public bool AttacksIfAble(ICard creature, IGame game)
        {
            return creature.Owner == _player;
        }

        public override IContinuousEffect Copy()
        {
            return new SlimeVeilContinuousEffect(this);
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn && phase.Turn.ActivePlayer == _player;
        }

        public override string ToString()
        {
            return $"During {_player}'s next turn, each of his creatures attacks if able.";
        }
    }
}
