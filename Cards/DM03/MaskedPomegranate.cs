using ContinuousEffects;

namespace Cards.DM03
{
    sealed class MaskedPomegranate : Creature
    {
        public MaskedPomegranate() : base("Masked Pomegranate", 5, 1000, Interfaces.Race.TreeFolk, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Interfaces.Civilization.Nature), new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(4000));
        }
    }
}
