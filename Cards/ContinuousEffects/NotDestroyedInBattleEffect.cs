using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class NotDestroyedInBattleEffect : ContinuousEffect, INotDestroyedInBattleEffect
    {
        private readonly Civilization _civilization;

        public NotDestroyedInBattleEffect(Civilization civilization) : base()
        {
            _civilization = civilization;
        }

        public NotDestroyedInBattleEffect(NotDestroyedInBattleEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public bool Applies(Engine.ICard against, Engine.ICard creature, IGame game)
        {
            return IsSourceOfAbility(creature, game) && against.HasCivilization(_civilization);
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