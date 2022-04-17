namespace Cards.Cards.DM06
{
    class DaidalosGeneralOfFury : Creature
    {
        public DaidalosGeneralOfFury() : base("Daidalos, General of Fury", 4, 11000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.SacrificeEffect());
            AddDoubleBreakerAbility();
        }
    }
}
