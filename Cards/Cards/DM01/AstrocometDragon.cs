using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class AstrocometDragon : Creature
    {
        public AstrocometDragon() : base("Astrocomet Dragon", 7, Civilization.Fire, 6000, Subtype.ArmoredDragon)
        {
            Abilities.Add(new PowerAttackerAbility(4000));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
