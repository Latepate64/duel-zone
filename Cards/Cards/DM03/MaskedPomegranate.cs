using Cards.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class MaskedPomegranate : Creature
    {
        public MaskedPomegranate() : base("Masked Pomegranate", 5, 1000, Engine.Race.TreeFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Engine.Civilization.Nature), new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(4000));
        }
    }
}
