using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM12
{
    class WiseStarnoidAvatarOfHope : VortexEvolutionCreature
    {
        public WiseStarnoidAvatarOfHope() : base("Wise Starnoid, Avatar of Hope", 5, 9000, Civilization.Light, Civilization.Water, Race.Starnoid, Race.LightBringer, Race.CyberLord)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksOrLeavesTheBattleZoneAbility(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect()));
        }
    }
}
