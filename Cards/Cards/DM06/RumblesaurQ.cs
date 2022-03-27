using Common;

namespace Cards.Cards.DM06
{
    class RumblesaurQ : Creature
    {
        public RumblesaurQ() : base("Rumblesaur Q", 6, 3000, Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.SurvivorAbility(new StaticAbilities.SpeedAttackerAbility()));
        }
    }
}
