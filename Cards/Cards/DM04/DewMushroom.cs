using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM04
{
    class DewMushroom : Creature
    {
        public DewMushroom() : base("Dew Mushroom", 3, 1000, Subtype.BalloonMushroom, Civilization.Nature)
        {
            AddAbilities(new EachCivilizationCardCostsMoreAbility(Civilization.Darkness, 1));
        }
    }
}
