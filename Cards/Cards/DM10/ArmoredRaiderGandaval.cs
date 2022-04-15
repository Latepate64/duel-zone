namespace Cards.Cards.DM10
{
    class ArmoredRaiderGandaval : EvolutionCreature
    {
        public ArmoredRaiderGandaval() : base("Armored Raider Gandaval", 5, 6000, Engine.Subtype.Human, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.DogarnTheMarauderEffect(2000));
            AddDoubleBreakerAbility();
        }
    }
}
