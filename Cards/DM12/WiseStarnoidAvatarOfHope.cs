using TriggeredAbilities;
using Interfaces;
using Abilities.Static;

namespace Cards.DM12
{
    sealed class WiseStarnoidAvatarOfHope : VortexEvolutionCreature
    {
        public WiseStarnoidAvatarOfHope() : base("Wise Starnoid, Avatar of Hope", 5, 9000, Civilization.Light, Civilization.Water, Race.Starnoid, Race.LightBringer, Race.CyberLord)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksOrLeavesTheBattleZoneAbility(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect()));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
