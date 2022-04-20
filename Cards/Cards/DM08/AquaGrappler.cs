using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM08
{
    class AquaGrappler : Creature
    {
        public AquaGrappler() : base("Aqua Grappler", 5, 3000, Race.LiquidPeople, Civilization.Water)
        {
            AddWheneverThisCreatureAttacksAbility(new AquaGrapplerEffect());
        }
    }

    class AquaGrapplerEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            var amount = game.BattleZone.GetCreatures(source.Controller).Count(x => x.Id != source.Source && x.Tapped == true);
            source.GetController(game).DrawCardsOptionally(game, source, amount);
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
