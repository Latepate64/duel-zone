using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class Soulswap : Spell
    {
        public Soulswap() : base("Soulswap", 3, Common.Civilization.Nature)
        {
            ShieldTrigger = true;
            // You may choose a creature in the battle zone and put it into its owner's mana zone. If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.
            Abilities.Add(new SpellAbility(new SoulswapEffect()));
        }
    }
}
