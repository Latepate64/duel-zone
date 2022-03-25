using Common;

namespace Cards.Cards.DM06
{
    class DaidalosGeneralOfFury : Creature
    {
        public DaidalosGeneralOfFury() : base("Daidalos, General of Fury", 4, 11000, Subtype.DemonCommand, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.SacrificeEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
