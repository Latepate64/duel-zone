using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM03
{
    class ChaosFish : Creature
    {
        public ChaosFish() : base("Chaos Fish", 7, 1000, Subtype.GelFish, Civilization.Water)
        {
            AddAbilities(new StaticAbilities.GetsPowerForEachOtherCivilizationCreatureYouControlAbility(Civilization.Water), new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new ChaosFishEffect()));
        }
    }

    class ChaosFishEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            return new OneShotEffects.YouMayDrawCardsEffect(game.GetAllCards(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Water), source.Controller).Count()).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new ChaosFishEffect();
        }

        public override string ToString()
        {
            return "You may draw a card for each of your other water creatures in the battle zone.";
        }
    }
}
