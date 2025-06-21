namespace Cards.DM01
{
    class ArmoredWalkerUrherion : Engine.Creature
    {
        public ArmoredWalkerUrherion() : base("Armored Walker Urherion", 4, 3000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(2000, Interfaces.Race.Human));
        }
    }
}
