namespace Cards.Cards.DM10
{
    class MezgerCommandoLeader : Creature
    {
        public MezgerCommandoLeader() : base("Mezger, Commando Leader", 4, 2000, Engine.Race.Human, Engine.Civilization.Fire)
        {
            AddSpeedAttackerAbility();
        }
    }
}
