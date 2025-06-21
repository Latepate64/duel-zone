using ContinuousEffects;

namespace Cards.DM01
{
    class RevolverFish : Engine.Creature
    {
        public RevolverFish() : base("Revolver Fish", 4, 5000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
