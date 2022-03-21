using Common;

namespace Cards.Cards.DM04
{
    class MissileBoy : Creature
    {
        public MissileBoy() : base("Missile Boy", 3, 1000, Subtype.Human, Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.EachCivilizationCardCostsMoreAbility(Civilization.Light, 1));
        }
    }
}
