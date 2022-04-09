using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM10
{
    class TerradragonDakmaBalgarow : Creature
    {
        public TerradragonDakmaBalgarow() : base("Terradragon Dakma Balgarow", 7, 1000, Subtype.EarthDragon, Civilization.Nature)
        {
            AddStaticAbilities(new TerradragonDakmaBalgarowEffect(), new ContinuousEffects.PoweredTripleBreaker());
        }
    }

    class TerradragonDakmaBalgarowEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public TerradragonDakmaBalgarowEffect() : base(2000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TerradragonDakmaBalgarowEffect();
        }

        public override string ToString()
        {
            return "This creature gets +2000 power for each shield you and your opponent have.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.Players.SelectMany(x => x.ShieldZone.Cards).Count();
        }
    }

    class ShieldZoneCardFilter : CardFilter
    {
        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return new CardFilters.OwnersShieldZoneCardFilter().Applies(card, game, player) && new CardFilters.OpponentsShieldZoneCardFilter().Applies(card, game, player);
        }

        public override ICardFilter Copy()
        {
            return new ShieldZoneCardFilter();
        }
    }
}
