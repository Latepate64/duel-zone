using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class MissileBoy : Creature
    {
        public MissileBoy() : base("Missile Boy", 3, 1000, Engine.Race.Human, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new EachCivilizationCardCostsMoreEffect(Engine.Civilization.Light, 1));
        }
    }
}
