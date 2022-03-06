using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM03
{
    class Emeral : Creature
    {
        public Emeral() : base("Emeral", 2, 1000, Common.Subtype.CyberLord, Common.Civilization.Water)
        {
            // When you put this creature into the battle zone, you may add a card from your hand to your shields face down. If you do, choose one of your shields and put it into your hand. You can't use the "shield trigger" ability of that shield.
            AddAbilities(new PutIntoPlayAbility(new EmeralEffect()));
        }
    }
}
