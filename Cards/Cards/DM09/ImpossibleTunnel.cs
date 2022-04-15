using Common;
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
        private readonly Subtype _subtype;

        public ImpossibleTunnelContinuousEffect(ImpossibleTunnelContinuousEffect effect) : base(effect)
        {
            _subtype = effect._subtype;
        }

        public ImpossibleTunnelContinuousEffect(Subtype subtype) : base()
        {
            _subtype = subtype;
        }

        public bool Applies(Engine.ICard attacker, Engine.ICard blocker, IGame game)
        {
            return game.BattleZone.Creatures.Where(x => x.HasSubtype(_subtype)).Contains(attacker);
        }

        public override IContinuousEffect Copy()
        {
            return new ImpossibleTunnelContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"{_subtype}s can't be blocked this turn.";
        }
    }
}
