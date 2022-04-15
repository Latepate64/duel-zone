using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class DewMushroom : Creature
    {
        public DewMushroom() : base("Dew Mushroom", 3, 1000, Engine.Subtype.BalloonMushroom, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new EachCivilizationCardCostsMoreEffect(Engine.Civilization.Darkness, 1));
        }
    }
}
