using OneShotEffects;
using Abilities;

namespace Cards.DM06
{
    sealed class RikabusScrewdriver : Creature
    {
        public RikabusScrewdriver() : base("Rikabu's Screwdriver", 2, 1000, Interfaces.Race.Xenoparts, Interfaces.Civilization.Fire)
        {
            AddAbilities(new TapAbility(new DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect()));
        }
    }
}
