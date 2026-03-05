using ContinuousEffects;

namespace Cards.DM01
{
    sealed class HunterFish : Creature
    {
        public HunterFish() : base("Hunter Fish", 2, 3000, Interfaces.Race.Fish, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
