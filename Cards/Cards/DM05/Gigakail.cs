using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class Gigakail : Creature
    {
        public Gigakail() : base("Gigakail", 5, 4000, Subtype.Chimera, Civilization.Darkness)
        {
            AddStaticAbilities(new CivilizationSlayerEffect(Civilization.Nature, Civilization.Light));
        }
    }
}
