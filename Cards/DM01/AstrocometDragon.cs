using Abilities.Static;
using ContinuousEffects.PowerModifying;

namespace Cards.DM01
{
    sealed class AstrocometDragon : Creature
    {
        public AstrocometDragon() : base("Astrocomet Dragon", 7, 6000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(4000));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
