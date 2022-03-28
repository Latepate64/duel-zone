using Common;

namespace Cards.Cards.DM07
{
    class SkyCrusherTheAgitator : Creature
    {
        public SkyCrusherTheAgitator() : base("Sky Crusher, the Agitator", 7, 4000, Subtype.Dragonoid, Civilization.Fire)
        {
            AddTapAbility(new OneShotEffects.MutualManaSacrificeEffect(1));
        }
    }
}
