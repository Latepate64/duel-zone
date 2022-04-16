namespace Cards.Cards.DM09
{
    class WhisperingTotem : Creature
    {
        public WhisperingTotem() : base("Whispering Totem", 4, 2000, Engine.Race.MysteryTotem, Engine.Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchCardWithNameEffect(Name));
        }
    }
}
