using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class DestroyAllCreaturesThatHaveExactPower : DestroyAreaOfEffect
    {
        private readonly int _power;

        public DestroyAllCreaturesThatHaveExactPower(int power) : base(new BattleZoneExactPowerCreatureFilter(1000))
        {
        }

        public DestroyAllCreaturesThatHaveExactPower(DestroyAllCreaturesThatHaveExactPower effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyAllCreaturesThatHaveExactPower(this);
        }

        public override string ToString()
        {
            return $"Destroy all creatures that have power {_power}.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.Creatures.Where(x => x.Power == _power);
        }
    }
}
