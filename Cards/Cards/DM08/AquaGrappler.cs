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
        public AquaGrapplerEffect()
        {
        }

        public AquaGrapplerEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var amount = game.BattleZone.GetCreatures(Applier).Count(x => x != Source && x.Tapped == true);
            Applier.DrawCardsOptionally(game, Ability, amount);
        }

        public override IOneShotEffect Copy()
        {
            return new AquaGrapplerEffect(this);
        }

        public override string ToString()
        {
            return "You may draw a card for each other tapped creature you have in the battle zone.";
        }
    }
}
