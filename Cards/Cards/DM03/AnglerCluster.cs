using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM03
{
    class AnglerCluster : Creature
    {
        public AnglerCluster() : base("Angler Cluster", 3, 3000, Engine.Subtype.CyberCluster, Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(Civilization.Water, 3000));
        }
    }
}
