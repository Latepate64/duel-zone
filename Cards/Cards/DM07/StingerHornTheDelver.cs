using Common;

namespace Cards.Cards.DM07
{
    class StingerHornTheDelver : Creature
    {
        public StingerHornTheDelver() : base("Stinger Horn, the Delver", 4, 3000, Subtype.HornedBeast, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.PowerAttackerAbility(1000), new StaticAbilities.StealthAbility(Civilization.Water));
        }
    }
}
