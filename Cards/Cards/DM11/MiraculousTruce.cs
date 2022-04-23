using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;

namespace Cards.Cards.DM11
{
    class MiraculousTruce : Spell
    {
        public MiraculousTruce() : base("Miraculous Truce", 5, Civilization.Light, Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new MiraculousTruceEffect());
        }
    }

    class MiraculousTruceEffect : OneShotEffect
    {
        public MiraculousTruceEffect()
        {
        }

        public MiraculousTruceEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var civilization = Controller.ChooseCivilization(ToString());
            game.AddContinuousEffects(Ability, new MiraculousTruceContinuousEffect(civilization, Controller));
        }

        public override IOneShotEffect Copy()
        {
            return new MiraculousTruceEffect(this);
        }

        public override string ToString()
        {
            return "Choose a civilization. Until the start of your next turn, creatures of that civilization can't attack you even if your opponent puts them into the battle zone after you cast this spell.";
        }
    }

    class MiraculousTruceContinuousEffect : ContinuousEffect, ICannotAttackPlayersEffect, IExpirable
    {
        private readonly Civilization _civilization;
        private readonly IPlayer _player;

        public MiraculousTruceContinuousEffect()
        {
        }

        public MiraculousTruceContinuousEffect(Civilization civilization, IPlayer player)
        {
            _civilization = civilization;
            _player = player;
        }

        public MiraculousTruceContinuousEffect(MiraculousTruceContinuousEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
            _player = effect._player;
        }

        public bool CannotAttackPlayers(ICard attacker, IGame game)
        {
            return attacker.HasCivilization(_civilization);
        }

        public override IContinuousEffect Copy()
        {
            return new MiraculousTruceContinuousEffect(this);
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.StartOfTurn && phase.Turn.ActivePlayer == _player;
        }

        public override string ToString()
        {
            return $"Until the start of your next turn, {_civilization} creatures can't attack you.";
        }
    }
}
