using Common;

namespace Cards.Cards.DM04
{
    class PurplePiercer : Creature
    {
        public PurplePiercer() : base("Purple Piercer", 3, 2000, Subtype.BrainJacker, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.ThisCreatureCannotBeAttackedByCivilizationCreaturesAbility(Civilization.Light), new StaticAbilities.ThisCreatureCannotBeBlockedByCivilizationCreaturesAbility(Civilization.Light));
        }
    }
}
