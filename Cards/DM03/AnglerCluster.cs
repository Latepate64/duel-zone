using Abilities.Static;
using ContinuousEffects.CannotAttack;
using ContinuousEffects.PowerModifying;

namespace Cards.DM03
{
    sealed class AnglerCluster : Creature
    {
        public AnglerCluster() : base("Angler Cluster", 3, 3000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(3000, Interfaces.Civilization.Water));
        }
    }
}
