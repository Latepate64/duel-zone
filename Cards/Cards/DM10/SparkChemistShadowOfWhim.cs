using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM10
{
    class SparkChemistShadowOfWhim : Creature
    {
        public SparkChemistShadowOfWhim() : base("Spark Chemist, Shadow of Whim", 2, 3000, Subtype.Ghost, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new SparkChemistShadowOfWhimEffect());
        }
    }

    class SparkChemistShadowOfWhimEffect : OneShotEffects.ManaRecoveryAreaOfEffect
    {
        public SparkChemistShadowOfWhimEffect() : base(new CardFilters.OwnersManaZoneCardFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SparkChemistShadowOfWhimEffect();
        }

        public override string ToString()
        {
            return "Return all the cards from your mana zone to your hand.";
        }

        protected override IEnumerable<Engine.ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.GetPlayer(source.Controller).ManaZone.Cards;
        }
    }
}
