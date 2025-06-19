using Cards.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class RocketdiveSkyterror : Creature
    {
        public RocketdiveSkyterror() : base("Rocketdive Skyterror", 4, 5000, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddPowerAttackerAbility(1000);
        }
    }
}
