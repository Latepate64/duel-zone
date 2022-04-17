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
        public override object Apply(IGame game, IAbility source)
        {
            new OneShotEffects.LookAtOneOfYourOpponentsShieldsEffect().Apply(game, source);
            source.GetController(game).DiscardAtRandom(game, 1, source);
            return null;
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
