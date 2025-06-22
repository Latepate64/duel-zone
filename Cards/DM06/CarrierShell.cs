using ContinuousEffects;

namespace Cards.DM06
{
    sealed class CarrierShell : Engine.Creature
    {
        public CarrierShell() : base("Carrier Shell", 3, 2000, Interfaces.Race.ColonyBeetle, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
