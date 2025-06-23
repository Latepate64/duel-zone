using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    sealed class VampireSilphy : Creature
    {
        public VampireSilphy() : base("Vampire Silphy", 8, 4000, Interfaces.Race.DarkLord, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyMaxPowerAreaOfEffect(3000)));
        }
    }
}
