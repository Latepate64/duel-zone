using ContinuousEffects.PowerModifying;

namespace Cards.DM10
{
    sealed class SiegeRollerBagash : Creature
    {
        public SiegeRollerBagash() : base("Siege Roller Bagash", 4, 3000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new DogarnTheMarauderEffect(1000));
        }
    }
}
