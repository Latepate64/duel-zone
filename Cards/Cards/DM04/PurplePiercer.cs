using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM04
{
    class PurplePiercer : Creature
    {
        public PurplePiercer() : base("Purple Piercer", 3, 2000, Subtype.BrainJacker, Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Civilization.Light), new ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(Civilization.Light));
        }
    }
}
