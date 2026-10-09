using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM01
{
    sealed class HunterFish : Creature
    {
        public HunterFish() : base("Hunter Fish", 2, 3000, Interfaces.Race.Fish, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
