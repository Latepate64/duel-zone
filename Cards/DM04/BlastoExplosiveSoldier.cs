using ContinuousEffects;

namespace Cards.DM04
{
    sealed class BlastoExplosiveSoldier : Engine.Creature
    {
        public BlastoExplosiveSoldier() : base("Blasto, Explosive Soldier", 3, 2000, Interfaces.Race.Dragonoid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(2000, Interfaces.Civilization.Darkness));
        }
    }
}
