using Common;

namespace Cards.Cards.DM07
{
    class KoocPollon : Creature
    {
        public KoocPollon() : base("Kooc Pollon", 2, 1000, Subtype.FireBird, Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.ThisCreatureCannotBeAttackedAbility());
        }
    }
}
