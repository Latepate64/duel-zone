using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM11
{
    class DiamondiaTheBlizzardRider : EvolutionCreature
    {
        public DiamondiaTheBlizzardRider() : base("Diamondia, the Blizzard Rider", 3, 5000, Subtype.SnowFaerie, Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new DiamondiaTheBlizzardRiderEffect());
        }
    }

    class DiamondiaTheBlizzardRiderEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.Move(ZoneType.Graveyard, ZoneType.Hand, source.GetController(game).Graveyard.Cards.Where(x => x.HasSubtype(Subtype.SnowFaerie)).ToArray());
            game.Move(ZoneType.ManaZone, ZoneType.Hand, source.GetController(game).ManaZone.Cards.Where(x => x.HasSubtype(Subtype.SnowFaerie)).ToArray());
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new DiamondiaTheBlizzardRiderEffect();
        }

        public override string ToString()
        {
            return "Return all Snow Faeries from your graveyard and your mana zone to your hand.";
        }
    }
}
