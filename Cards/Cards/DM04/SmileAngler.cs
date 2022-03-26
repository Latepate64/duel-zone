using Common;
using Engine.Abilities;

namespace Cards.Cards.DM04
{
    class SmileAngler : Creature
    {
        public SmileAngler() : base("Smile Angler", 6, 3000, Subtype.GelFish, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new SmileAnglerEffect()));
        }
    }

    class SmileAnglerEffect : OneShotEffects.OpponentManaRecoveryEffect
    {
        public SmileAnglerEffect() : base(0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SmileAnglerEffect();
        }

        public override string ToString()
        {
            return "You may choose a card in your opponent's mana zone and return it to his hand.";
        }
    }
}
