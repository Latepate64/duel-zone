using Cards.ContinuousEffects;
using ContinuousEffects;

namespace Cards.Cards.DM01
{
    class RevolverFish : Engine.Creature
    {
        public RevolverFish() : base("Revolver Fish", 4, 5000, Engine.Race.GelFish, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
