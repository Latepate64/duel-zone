using ContinuousEffects;

namespace Cards.DM06
{
    class CarrierShell : Engine.Creature
    {
        public CarrierShell() : base("Carrier Shell", 3, 2000, Engine.Race.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
