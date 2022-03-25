using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM03
{
    class MaskedPomegranate : Creature
    {
        public MaskedPomegranate() : base("Masked Pomegranate", 5, 1000, Subtype.TreeFolk, Civilization.Nature)
        {
            AddAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlAbility(Civilization.Nature), new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerAbility(4000));
        }
    }
}
