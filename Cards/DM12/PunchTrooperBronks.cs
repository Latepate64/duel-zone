using TriggeredAbilities;

namespace Cards.DM12
{
    sealed class PunchTrooperBronks : Engine.Creature
    {
        public PunchTrooperBronks() : base("Punch Trooper Bronks", 4, 3000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ScreamSlicerShadowOfFearEffect()));
        }
    }
}
