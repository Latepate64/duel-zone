using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM08
{
    class AquaRanger : Creature
    {
        public AquaRanger() : base("Aqua Ranger", 6, Civilization.Water, 3000, Subtype.LiquidPeople)
        {
            Abilities.Add(new UnblockableAbility());
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
