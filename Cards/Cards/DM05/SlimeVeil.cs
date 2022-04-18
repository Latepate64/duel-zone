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
        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new SlimeVeilContinuousEffect());
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new SlimeVeilOneShotEffect();
        }

        public override string ToString()
        {
            return "During your opponent's next turn, each of his creatures attacks if able.";
        }
    }

    class SlimeVeilContinuousEffect : ContinuousEffect, IAttacksIfAbleEffect, IExpirable
    {
        public SlimeVeilContinuousEffect()
        {
        }

        public SlimeVeilContinuousEffect(SlimeVeilContinuousEffect effect) : base(effect)
        {
        }

        public bool AttacksIfAble(ICard creature, IGame game)
        {
            return creature.Owner == game.GetOpponent(GetController(game)).Id;
        }

        public override IContinuousEffect Copy()
        {
            return new SlimeVeilContinuousEffect(this);
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn && phase.Turn.ActivePlayer == game.GetOpponent(GetController(game));
        }

        public override string ToString()
        {
            return "Each of your opponent's creatures attacks if able.";
        }
    }
}
