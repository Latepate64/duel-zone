namespace Cards.DM04
{
    class KamikazeChainsawWarrior : Engine.Creature
    {
        public KamikazeChainsawWarrior() : base("Kamikaze, Chainsaw Warrior", 2, 1000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddShieldTrigger();
        }
    }
}
