using Cards.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class WildRacerChiefGaran : Engine.Creature
    {
        public WildRacerChiefGaran() : base("Wild Racer Chief Garan", 3, 2000, Engine.Race.Human, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(1000));
            AddStaticAbilities(new StealthEffect(Engine.Civilization.Light));
        }
    }
}
