using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM09
{
    class ImpossibleTunnel : Spell
    {
        public ImpossibleTunnel() : base("Impossible Tunnel", 5, Civilization.Water)
        {
            AddSpellAbilities(new ImpossibleTunnelOneShotEffect());
        }
    }

    class ImpossibleTunnelOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new ImpossibleTunnelContinuousEffect(source.GetController(game).ChooseRace(ToString())));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new ImpossibleTunnelOneShotEffect();
        }

        public override string ToString()
        {
            return "Choose a race. Creatures of that race can't be blocked this turn.";
        }
    }

    class ImpossibleTunnelContinuousEffect : ContinuousEffects.UntilEndOfTurnEffect, IUnblockableEffect
    {
        private readonly Race _race;

        public ImpossibleTunnelContinuousEffect(ImpossibleTunnelContinuousEffect effect) : base(effect)
        {
            _race = effect._race;
        }

        public ImpossibleTunnelContinuousEffect(Race race) : base()
        {
            _race = race;
        }

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IAttackable targetOfAttack, IGame game)
        {
            return game.BattleZone.Creatures.Where(x => x.HasRace(_race)).Contains(attacker);
        }

        public override IContinuousEffect Copy()
        {
            return new ImpossibleTunnelContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"{_race}s can't be blocked this turn.";
        }
    }
}
