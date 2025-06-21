using ContinuousEffects;

namespace Cards.DM07
{
    class WildRacerChiefGaran : Engine.Creature
    {
        public WildRacerChiefGaran() : base("Wild Racer Chief Garan", 3, 2000, Interfaces.Race.Human, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(1000));
            AddStaticAbilities(new StealthEffect(Interfaces.Civilization.Light));
        }
    }
}
