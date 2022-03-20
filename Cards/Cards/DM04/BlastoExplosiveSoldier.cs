using Common;

namespace Cards.Cards.DM04
{
    class BlastoExplosiveSoldier : Creature
    {
        public BlastoExplosiveSoldier() : base("Blasto, Explosive Soldier", 3, 2000, Subtype.Dragonoid, Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.WhileYouControlCivilizationCreatureThisCreatureGetsPowerAbility(Civilization.Darkness, 2000));
        }
    }
}
