using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM01
{
    class VampireSilphy : Creature
    {
        public VampireSilphy() : base("Vampire Silphy", 8, 4000, Subtype.DarkLord, Civilization.Darkness)
        {
            // When you put this creature into the battle zone, destroy all creatures that have power 3000 or less.
            AddAbilities(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyMaxPowerAreaOfEffect(3000)));
        }
    }
}
