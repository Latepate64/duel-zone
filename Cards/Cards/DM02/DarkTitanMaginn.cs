namespace Cards.Cards.DM02
{
    class DarkTitanMaginn : Creature
    {
        public DarkTitanMaginn() : base("Dark Titan Maginn", 6, 4000, Engine.Subtype.DemonCommand, Engine.Civilization.Darkness)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.OpponentRandomDiscardEffect());
        }
    }
}
