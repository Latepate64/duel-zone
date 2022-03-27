using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM08
{
    class AquaRanger : Creature
    {
        public AquaRanger() : base("Aqua Ranger", 6, 3000, Subtype.LiquidPeople, Civilization.Water)
        {
            AddAbilities(new ThisCreatureCannotBeBlockedAbility(), new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
