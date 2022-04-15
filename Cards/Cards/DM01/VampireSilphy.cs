using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class VampireSilphy : Creature
    {
        public VampireSilphy() : base("Vampire Silphy", 8, 4000, Engine.Subtype.DarkLord, Engine.Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyMaxPowerAreaOfEffect(3000));
        }
    }
}
