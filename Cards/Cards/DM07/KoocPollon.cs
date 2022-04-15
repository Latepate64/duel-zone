using Common;

namespace Cards.Cards.DM07
{
    class KoocPollon : Creature
    {
        public KoocPollon() : base("Kooc Pollon", 2, 1000, Engine.Subtype.FireBird, Civilization.Fire)
        {
            AddThisCreatureCannotBeAttackedAbility();
        }
    }
}
