using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class DestroyMaxPowerAreaOfEffect : DestroyAreaOfEffect
    {
        private readonly int _power;

        public DestroyMaxPowerAreaOfEffect(int power) : base()
        {
            _power = power;
        }

        public DestroyMaxPowerAreaOfEffect(DestroyMaxPowerAreaOfEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyMaxPowerAreaOfEffect(this);
        }

        public override string ToString()
        {
            return $"Destroy all creatures that have power {_power} or less.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.Creatures.Where(x => x.Power <= _power);
        }
    }
}
