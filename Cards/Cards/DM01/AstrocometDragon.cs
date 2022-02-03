using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM01
{
    public class AstrocometDragon : Creature
    {
        public AstrocometDragon() : base("Astrocomet Dragon", 7, Common.Civilization.Fire, 6000, Common.Subtype.ArmoredDragon)
        {
            Abilities.Add(new PowerAttackerAbility(4000));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
