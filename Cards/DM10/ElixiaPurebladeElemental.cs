using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM10
{
    sealed class ElixiaPurebladeElemental : Creature
    {
        public ElixiaPurebladeElemental() : base("Elixia, Pureblade Elemental", 6, 1000, Race.AngelCommand, Civilization.Light)
        {
            AddStaticAbilities(new ElixiaEffect(), new PoweredTripleBreaker());
        }
    }

    sealed class ElixiaEffect : PowerModifyingMultiplierEffect
    {
        public ElixiaEffect(int power = 3000) : base(power)
        {
        }

        public ElixiaEffect(ElixiaEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ElixiaEffect(this);
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power for each civilization in your mana zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return Controller.ManaZone.Cards.SelectMany(x => x.Civilizations).Distinct().Count();
        }
    }
}
