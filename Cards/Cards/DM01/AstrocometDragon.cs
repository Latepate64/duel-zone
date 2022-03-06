using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class AstrocometDragon : Creature
    {
        public AstrocometDragon() : base("Astrocomet Dragon", 7, Common.Civilization.Fire, 6000, Common.Subtype.ArmoredDragon)
        {
            Abilities.Add(new PowerAttackerAbility(4000));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
