using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM10
{
    public class AquaSkydiver : Creature
    {
        public AquaSkydiver() : base("Aqua Skydiver", 4, new[] { Civilization.Light, Civilization.Water }, 1000, new[] { Subtype.LiquidPeople })
        {
            ShieldTrigger = true;
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
