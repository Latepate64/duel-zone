using Common;

namespace Cards.Cards.DM12
{
    class PunchTrooperBronks : Creature
    {
        public PunchTrooperBronks() : base("Punch Trooper Bronks", 4, 3000, Engine.Subtype.Armorloid, Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ScreamSlicerShadowOfFearEffect());
        }
    }
}
