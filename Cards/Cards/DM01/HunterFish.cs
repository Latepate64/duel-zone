using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class HunterFish : Engine.Creature
    {
        public HunterFish() : base("Hunter Fish", 2, 3000, Engine.Race.Fish, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
