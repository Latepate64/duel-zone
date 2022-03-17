using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM03
{
    class Scratchclaw : Creature
    {
        public Scratchclaw() : base("Scratchclaw", 4, 1000, Subtype.Hedrian, Civilization.Darkness)
        {
            AddAbilities(new SlayerAbility(), new GetsPowerForEachOtherCivilizationCreatureYouControlAbility(Civilization.Darkness));
        }
    }
}
