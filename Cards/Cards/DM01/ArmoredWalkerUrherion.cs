namespace Cards.Cards.DM01
{
    class ArmoredWalkerUrherion : Creature
    {
        public ArmoredWalkerUrherion() : base("Armored Walker Urherion", 4, 3000, Engine.Subtype.Armorloid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect(Engine.Subtype.Human, 2000));
        }
    }
}
