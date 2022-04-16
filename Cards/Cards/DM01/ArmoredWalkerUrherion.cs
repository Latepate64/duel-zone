namespace Cards.Cards.DM01
{
    class ArmoredWalkerUrherion : Creature
    {
        public ArmoredWalkerUrherion() : base("Armored Walker Urherion", 4, 3000, Engine.Race.Armorloid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(Engine.Race.Human, 2000));
        }
    }
}
