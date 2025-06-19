using Cards.ContinuousEffects;
using Effects.Continuous;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;

namespace Cards.Cards.DM10
{
    class ForcedFrenzy : Spell
    {
        public ForcedFrenzy() : base("Forced Frenzy", 3, Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new ForcedFrenzyEffect());
        }
    }

    class ForcedFrenzyEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Ability, new ForcedFrenzyContinuousEffect(GetOpponent(game)));
        }

        public override IOneShotEffect Copy()
        {
            return new ForcedFrenzyEffect();
        }

        public override string ToString()
        {
            return "Each of your opponent's creatures gets \"This creature attacks if able\" until the start of your next turn.";
        }
    }

    class ForcedFrenzyContinuousEffect : ContinuousEffect, IAttacksIfAbleEffect, IExpirable
    {
        private readonly Player _opponent;

        public ForcedFrenzyContinuousEffect(Player opponent)
        {
            _opponent = opponent;
        }

        public ForcedFrenzyContinuousEffect(ForcedFrenzyContinuousEffect effect) : base(effect)
        {
            _opponent = effect._opponent;
        }

        public bool AttacksIfAble(Creature creature, IGame game)
        {
            return creature.Owner == _opponent;
        }

        public override IContinuousEffect Copy()
        {
            return new ForcedFrenzyContinuousEffect(this);
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.StartOfTurn && phase.Turn.ActivePlayer == Controller;
        }

        public override string ToString()
        {
            return $"Each of {_opponent}'s creatures attacks if able until the start of your next turn.";
        }
    }
}
