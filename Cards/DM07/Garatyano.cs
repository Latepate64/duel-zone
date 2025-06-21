using OneShotEffects;
using Engine;
using Engine.Abilities;

namespace Cards.DM07
{
    class Garatyano : Creature
    {
        public Garatyano() : base("Garatyano", 4, 2000, Race.SeaHacker, Civilization.Water)
        {
            AddAbilities(new TapAbility(new GaratyanoEffect()));
        }
    }

    class GaratyanoEffect : LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect
    {
        public GaratyanoEffect() : base(3)
        {
        }

        public GaratyanoEffect(LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new GaratyanoEffect(this);
        }
    }
}
