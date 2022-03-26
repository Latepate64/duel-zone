using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class RikabusScrewdriver : Creature
    {
        public RikabusScrewdriver() : base("Rikabu's Screwdriver", 2, 1000, Common.Subtype.Xenoparts, Common.Civilization.Fire)
        {
            AddAbilities(new TapAbility(new DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect()));
        }
    }
}
