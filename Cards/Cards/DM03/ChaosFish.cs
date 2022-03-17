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
            AddAbilities(new StaticAbilities.GetsPowerForEachOtherCivilizationCreatureYouControlAbility(Civilization.Water), new TriggeredAbilities.AttackAbility(new ChaosFishEffect()));
        }
    }

    class ChaosFishEffect : OneShotEffect
    {
        public override object Apply(Game game, Ability source)
        {
            return new OneShotEffects.ControllerMayDrawCardsEffect(game.GetAllCards(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Water), source.Owner).Count()).Apply(game, source);
        }

        public override OneShotEffect Copy()
        {
            return new ChaosFishEffect();
        }

        public override string ToString()
        {
            return "You may draw a card for each of your other water creatures in the battle zone.";
        }
    }
}
