using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM10
{
    class ElixiaPurebladeElemental : Creature
    {
        public ElixiaPurebladeElemental() : base("Elixia, Pureblade Elemental", 6, 1000, Race.AngelCommand, Civilization.Light)
        {
            AddStaticAbilities(new ElixiaEffect(), new PoweredTripleBreaker());
        }
    }

    class ElixiaEffect : PowerModifyingMultiplierEffect
    {
        public ElixiaEffect() : base(3000)
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
            return "This creature gets +3000 power for each civilization in your mana zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return GetController(game).ManaZone.Cards.SelectMany(x => x.Civilizations).Distinct().Count();
        }
    }
}
