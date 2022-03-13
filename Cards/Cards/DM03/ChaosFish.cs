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
            AddAbilities(new StaticAbility(new ContinuousEffects.PowerModifyingMultiplierEffect(1000, new CardFilters.OwnersBattleZoneCreatureExceptFilter(Civilization.Water))), new TriggeredAbilities.AttackAbility(new ChaosFishEffect()));
        }
    }

    class ChaosFishEffect : OneShotEffect
    {
        public override object Apply(Game game, Ability source)
        {
            return new OneShotEffects.ControllerMayDrawCardsEffect(game.GetAllCards(new CardFilters.OwnersBattleZoneCreatureExceptFilter(Civilization.Water), source.Owner).Count()).Apply(game, source);
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
