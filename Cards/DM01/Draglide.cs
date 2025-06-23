namespace Cards.DM01
{
    sealed class Draglide : Creature
    {
        public Draglide() : base("Draglide", 5, 5000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureAttacksEachTurnIfAbleEffect());
        }
    }
}
