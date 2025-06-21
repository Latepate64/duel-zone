namespace Cards.DM01
{
    class Draglide : Engine.Creature
    {
        public Draglide() : base("Draglide", 5, 5000, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureAttacksEachTurnIfAbleEffect());
        }
    }
}
