using Engine.Abilities;
using System;

namespace Engine
{
    public interface IEffect
    {
        Guid SourceAbility { get; set; }
    }

    public abstract class Effect : IEffect
    {
        protected Effect()
        {
        }

        protected Effect(IEffect effect)
        {
            SourceAbility = effect.SourceAbility;
        }

        public Guid SourceAbility { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                SourceAbility = Guid.Empty;
            }
        }

        public override abstract string ToString();

        protected IAbility GetSourceAbility(IGame game)
        {
            return game.GetAbility(SourceAbility);
        }

        protected bool IsSourceOfAbility(ICard card, IGame game)
        {
            return card.Id == GetSourceAbility(game).Source;
        }

        protected ICard GetSourceCard(IGame game)
        {
            return game.GetCard(GetSourceAbility(game).Source);
        }

        protected IPlayer GetController(IGame game)
        {
            IAbility ability = GetSourceAbility(game);
            return ability.GetController(game);
        }

        protected IPlayer GetOpponent(IGame game)
        {
            return game.GetOpponent(GetController(game));
        }
    }
}
