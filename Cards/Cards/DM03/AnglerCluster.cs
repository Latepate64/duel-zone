using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM03
{
    class AnglerCluster : Creature
    {
        public AnglerCluster() : base("Angler Cluster", 3, 3000, Subtype.CyberCluster, Civilization.Water)
        {
            AddAbilities(new BlockerAbility(), new CannotAttackAbility(), new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerAbility(Civilization.Water, 3000));
        }
    }
}
