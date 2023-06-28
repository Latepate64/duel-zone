using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM10
{
    class TerradragonDakmaBalgarow : Creature
    {
        public TerradragonDakmaBalgarow() : base("Terradragon Dakma Balgarow", 7, 1000, Race.EarthDragon, Civilization.Nature)
        {
            AddStaticAbilities(new TerradragonDakmaBalgarowEffect(), new ContinuousEffects.PoweredTripleBreaker());
        }
    }

    class TerradragonDakmaBalgarowEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public TerradragonDakmaBalgarowEffect(int power = 2000) : base(power)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TerradragonDakmaBalgarowEffect();
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power for each shield you and your opponent have.";
        }

        protected override int GetMultiplier()
        {
            return Game.Players.SelectMany(x => x.ShieldZone.Cards).Count();
        }
    }
}
