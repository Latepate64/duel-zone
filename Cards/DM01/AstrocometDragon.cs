using ContinuousEffects;

namespace Cards.DM01
{
    class AstrocometDragon : Engine.Creature
    {
        public AstrocometDragon() : base("Astrocomet Dragon", 7, 6000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(4000), new DoubleBreakerEffect());
        }
    }
}
