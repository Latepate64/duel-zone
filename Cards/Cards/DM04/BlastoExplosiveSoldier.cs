using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class BlastoExplosiveSoldier : Creature
    {
        public BlastoExplosiveSoldier() : base("Blasto, Explosive Soldier", 3, 2000, Engine.Race.Dragonoid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(2000, Engine.Civilization.Darkness));
        }
    }
}
