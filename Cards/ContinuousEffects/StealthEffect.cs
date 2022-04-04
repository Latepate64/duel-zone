using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class StealthEffect : ContinuousEffect, IUnblockableEffect
    {
        private readonly Civilization _civilization;

        public StealthEffect(Civilization civilization) : base(new TargetFilter(), new Durations.Indefinite())
        {
            _civilization = civilization;
        }

        public StealthEffect(StealthEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public bool Applies(Engine.ICard blocker, IGame game)
        {
            return game.GetAbility(SourceAbility).GetOpponent(game).ManaZone.Cards.Any(x => x.HasCivilization(_civilization));
        }

        public override IContinuousEffect Copy()
        {
            return new StealthEffect(this);
        }

        public override string ToString()
        {
            return $"{_civilization} stealth";
        }
    }
}