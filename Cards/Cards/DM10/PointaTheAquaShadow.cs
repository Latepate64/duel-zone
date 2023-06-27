using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class PointaTheAquaShadow : Creature
    {
        public PointaTheAquaShadow() : base("Pointa, the Aqua Shadow", 5, 2000, Race.LiquidPeople, Race.Ghost, Civilization.Water, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new PointaTheAquaShadowEffect());
        }
    }

    class PointaTheAquaShadowEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var controller = Applier;
            controller.LookAtOneOfOpponentsShields(game, Ability);
            game.GetOpponent(controller).DiscardAtRandom(game, 1, Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new PointaTheAquaShadowEffect();
        }

        public override string ToString()
        {
            return "Look at one of your opponent's shields. Then your opponent discards a card at random from his hand.";
        }
    }
}
