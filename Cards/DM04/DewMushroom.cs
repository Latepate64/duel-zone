using ContinuousEffects;
using Interfaces.ContinuousEffects;

namespace Cards.DM04
{
    class DewMushroom : Engine.Creature
    {
        public DewMushroom() : base("Dew Mushroom", 3, 1000, Interfaces.Race.BalloonMushroom, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new DewMushroomEffect());
        }
    }

    class DewMushroomEffect : EachCivilizationCardCostsMoreEffect
    {
        public DewMushroomEffect(EachCivilizationCardCostsMoreEffect effect) : base(effect)
        {
        }

        public DewMushroomEffect(Interfaces.Civilization civilization = Interfaces.Civilization.Darkness) : base(1, civilization)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new DewMushroomEffect(this);
        }
    }
}
