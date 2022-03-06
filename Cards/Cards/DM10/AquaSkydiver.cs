using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM10
{
    public class AquaSkydiver : Creature
    {
        public AquaSkydiver() : base("Aqua Skydiver", 4, 1000)
        {
            AddCivilizations(Civilization.Light, Civilization.Water);
            AddSubtypes(Subtype.LiquidPeople);

            ShieldTrigger = true;
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
