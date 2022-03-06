using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM10
{
    class AquaSkydiver : Creature
    {
        public AquaSkydiver() : base("Aqua Skydiver", 4, 1000, Subtype.LiquidPeople, Civilization.Light, Civilization.Water)
        {
            ShieldTrigger = true;
            AddAbilities(new BlockerAbility(), new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
