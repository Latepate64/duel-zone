using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM08
{
    class AquaGrappler : Creature
    {
        public AquaGrappler() : base("Aqua Grappler", 5, 3000, Subtype.LiquidPeople, Civilization.Water)
        {
            AddWheneverThisCreatureAttacksAbility(new AquaGrapplerEffect());
        }
    }

    class AquaGrapplerEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            return new OneShotEffects.YouMayDrawCardsEffect(game.GetAllCards(new CardFilters.OwnersBattleZoneTappedCreatureExceptFilter(), source.Controller).Count()).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new AquaGrapplerEffect();
        }

        public override string ToString()
        {
            return "You may draw a card for each other tapped creature you have in the battle zone.";
        }
    }
}
