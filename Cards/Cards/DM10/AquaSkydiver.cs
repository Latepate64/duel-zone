using Cards.StaticAbilities;
using Common;
using System.Collections.Generic;

namespace Cards.Cards.DM10
{
    public class AquaSkydiver : Creature
    {
        public AquaSkydiver() : base("Aqua Skydiver", 4, 1000)
        {
            Civilizations.Add(Civilization.Light);
            Civilizations.Add(Civilization.Water);
            Subtypes.Add(Subtype.LiquidPeople);

            ShieldTrigger = true;
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
