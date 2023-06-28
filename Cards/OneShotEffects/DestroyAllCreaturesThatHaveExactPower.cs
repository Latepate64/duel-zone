using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class DestroyAllCreaturesThatHaveExactPower : DestroyAreaOfEffect
    {
        private readonly int _power;

        public DestroyAllCreaturesThatHaveExactPower(int power) : base()
        {
            _power = power;
        }

        public DestroyAllCreaturesThatHaveExactPower(DestroyAllCreaturesThatHaveExactPower effect) : base(effect)
        {
            _power = effect._power;
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyAllCreaturesThatHaveExactPower(this);
        }

        public override string ToString()
        {
            return $"Destroy all creatures that have power {_power}.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IAbility source)
        {
            return Game.BattleZone.Creatures.Where(x => x.Power == _power);
        }
    }
}
