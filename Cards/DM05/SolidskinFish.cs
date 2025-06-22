using TriggeredAbilities;

namespace Cards.DM05
{
    sealed class SolidskinFish : Engine.Creature
    {
        public SolidskinFish() : base("Solidskin Fish", 3, 3000, Interfaces.Race.Fish, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect()));
        }
    }
}
