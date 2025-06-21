using ContinuousEffects;

namespace Cards.DM08
{
    class RocketdiveSkyterror : Engine.Creature
    {
        public RocketdiveSkyterror() : base("Rocketdive Skyterror", 4, 5000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddStaticAbilities(new PowerAttackerEffect(1000));
        }
    }
}
