using Cards.ContinuousEffects;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class DewMushroom : Creature
    {
        public DewMushroom() : base("Dew Mushroom", 3, 1000, Engine.Race.BalloonMushroom, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new DewMushroomEffect());
        }
    }

    class DewMushroomEffect : EachCivilizationCardCostsMoreEffect
    {
        public DewMushroomEffect(EachCivilizationCardCostsMoreEffect effect) : base(effect)
        {
        }

        public DewMushroomEffect(Engine.Civilization civilization = Engine.Civilization.Darkness) : base(1, civilization)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new DewMushroomEffect(this);
        }
    }
}
