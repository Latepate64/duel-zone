using Common;

namespace Cards.Cards.DM10
{
    class SiegeRollerBagash : Creature
    {
        public SiegeRollerBagash() : base("Siege Roller Bagash", 4, 3000, Engine.Subtype.Armorloid, Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.DogarnTheMarauderEffect(1000));
        }
    }
}
