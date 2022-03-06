using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class AstrocometDragon : Creature
    {
        public AstrocometDragon() : base("Astrocomet Dragon", 7, 6000, Common.Subtype.ArmoredDragon, Common.Civilization.Fire)
        {
            AddAbilities(new PowerAttackerAbility(4000), new DoubleBreakerAbility());
        }
    }
}
