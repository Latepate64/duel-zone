using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM03
{
    class MaskedPomegranate : Creature
    {
        public MaskedPomegranate() : base("Masked Pomegranate", 5, 1000, Engine.Subtype.TreeFolk, Civilization.Nature)
        {
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Civilization.Nature), new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(4000));
        }
    }
}
