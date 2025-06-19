using Abilities.Triggered;

namespace Cards.Cards.DM12
{
    class PunchTrooperBronks : Engine.Creature
    {
        public PunchTrooperBronks() : base("Punch Trooper Bronks", 4, 3000, Engine.Race.Armorloid, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ScreamSlicerShadowOfFearEffect()));
        }
    }
}
