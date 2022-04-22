using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class AquaStrummer : Creature
    {
        public AquaStrummer() : base("Aqua Strummer", 3, 2000, Race.LiquidPeople, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new AquaStrummerEffect());
        }
    }

    class AquaStrummerEffect : LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect
    {
        public AquaStrummerEffect() : base(5)
        {
        }

        public AquaStrummerEffect(LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new AquaStrummerEffect(this);
        }
    }
}
