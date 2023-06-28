using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class ClonedEffect : OneShotEffect
    {
        private readonly string _name;

        protected ClonedEffect(string name)
        {
            _name = name;
        }

        protected ClonedEffect(ClonedEffect effect)
        {
            _name = effect._name;
        }

        protected int GetAmount()
        {
            return 1 + Game.Players.SelectMany(x => x.Graveyard.Cards.Where(x => x.Name == _name)).Count();
        }
    }
}
