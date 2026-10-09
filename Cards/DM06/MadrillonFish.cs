using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM06
{
    sealed class MadrillonFish : Creature
    {
        public MadrillonFish() : base("Madrillon Fish", 2, 3000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
