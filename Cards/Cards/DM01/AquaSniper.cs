using TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class AquaSniper : Engine.Creature
    {
        public AquaSniper() : base("Aqua Sniper", 8, 5000, Engine.Race.LiquidPeople, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect()));
        }
    }
}
