using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class AstrocometDragon : Creature
    {
        public AstrocometDragon() : base("Astrocomet Dragon", 7, 6000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(4000), new DoubleBreakerEffect());
        }
    }
}
