using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM01
{
    sealed class MarineFlower : Creature
    {
        public MarineFlower() : base("Marine Flower", 1, 2000, Interfaces.Race.CyberVirus, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
