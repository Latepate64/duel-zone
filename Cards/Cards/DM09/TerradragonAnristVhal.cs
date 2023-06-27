using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM09
{
    class TerradragonAnristVhal : Creature
    {
        public TerradragonAnristVhal() : base("Terradragon Anrist Vhal", 6, 0, Race.EarthDragon, Civilization.Nature)
        {
            AddStaticAbilities(new TerradragonAnristVhalEffect(), new ContinuousEffects.PoweredDoubleBreaker());
        }
    }

    class TerradragonAnristVhalEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public TerradragonAnristVhalEffect(int power = 2000) : base(power)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TerradragonAnristVhalEffect();
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power for each of your other nature creatures in the battle zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.BattleZone.GetOtherCreatures(Applier.Id, Source.Id, Civilization.Nature).Count();
        }
    }
}
