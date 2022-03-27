using Common;

namespace Cards.Cards.DM05
{
    class Gigakail : Creature
    {
        public Gigakail() : base("Gigakail", 5, 4000, Subtype.Chimera, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.CivilizationSlayerAbility(Civilization.Nature, Civilization.Light));
        }
    }
}
