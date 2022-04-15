namespace Cards.Cards.DM02
{
    class SilverAxe : Creature
    {
        public SilverAxe() : base("Silver Axe", 3, 1000, Engine.Subtype.BeastFolk, Engine.Civilization.Nature)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.MayPutTopCardOfDeckIntoManaZoneEffect());
        }
    }
}
