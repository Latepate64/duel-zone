using Cards.StaticAbilities;
using Common;
using System.Collections.Generic;

namespace Cards.Cards.DM10
{
    public class AquaSkydiver : Creature
    {
        public AquaSkydiver() : base("Aqua Skydiver", 4, new List<Civilization> { Civilization.Light, Civilization.Water }, 1000, new List<Subtype> { Subtype.LiquidPeople })
        {
            ShieldTrigger = true;
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
