using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM09
{
    sealed class TerradragonAnristVhal : Creature
    {
        public TerradragonAnristVhal() : base("Terradragon Anrist Vhal", 6, 0, Race.EarthDragon, Civilization.Nature)
        {
            AddStaticAbilities(new TerradragonAnristVhalEffect(), new ContinuousEffects.PoweredDoubleBreaker());
        }
    }

    sealed class TerradragonAnristVhalEffect(int power = 2000) : ContinuousEffects.PowerModifyingMultiplierEffect(power)
    {
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
            return game.BattleZone.GetOtherCreatureCount(Controller.Id, Source.Id, Civilization.Nature);
        }
    }
}
