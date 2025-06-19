using Cards.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class BoltailDragon : Engine.Creature
    {
        public BoltailDragon() : base("Boltail Dragon", 7, 9000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
