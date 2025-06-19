using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class VampireSilphy : Creature
    {
        public VampireSilphy() : base("Vampire Silphy", 8, 4000, Engine.Race.DarkLord, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyMaxPowerAreaOfEffect(3000)));
        }
    }
}
