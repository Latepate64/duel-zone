using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM08
{
    class RocketdiveSkyterror : Engine.Creature
    {
        public RocketdiveSkyterror() : base("Rocketdive Skyterror", 4, 5000, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddStaticAbilities(new PowerAttackerEffect(1000));
        }
    }
}
