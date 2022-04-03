using Common;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class NotDestroyedInBattleEffect : ContinuousEffect, INotDestroyedInBattleEffect
    {
        private readonly Civilization _civilization;

        public NotDestroyedInBattleEffect(Civilization civilization) : base(new Engine.TargetFilter(), new Durations.Indefinite())
        {
            _civilization = civilization;
        }

        public NotDestroyedInBattleEffect(NotDestroyedInBattleEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public bool Applies(Engine.ICard against)
        {
            return against.HasCivilization(_civilization);
        }

        public override IContinuousEffect Copy()
        {
            return new NotDestroyedInBattleEffect(this);
        }

        public override string ToString()
        {
            return $"When this creature loses a battle against a {_civilization.ToString().ToLower()} creature, this creature isn't destroyed.";
        }
    }
}