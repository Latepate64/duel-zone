using TriggeredAbilities;

namespace Cards.DM01
{
    class AquaSniper : Engine.Creature
    {
        public AquaSniper() : base("Aqua Sniper", 8, 5000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect()));
        }
    }
}
