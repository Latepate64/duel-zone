using Abilities.Static;
using ContinuousEffects.PowerModifying;

namespace Cards.DM05
{
    sealed class BolgashDragon : Creature
    {
        public BolgashDragon() : base("Bolgash Dragon", 8, 4000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(8000));
            AddAbilities(new TripleBreakerAbility());
        }
    }
}
