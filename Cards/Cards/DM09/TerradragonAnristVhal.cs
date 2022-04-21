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
        public TerradragonAnristVhalEffect() : base(2000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TerradragonAnristVhalEffect();
        }

        public override string ToString()
        {
            return "This creature gets +2000 power for each of your other nature creatures in the battle zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.BattleZone.GetOtherCreatures(Controller.Id, GetSourceCard(game).Id, Civilization.Nature).Count();
        }
    }
}
