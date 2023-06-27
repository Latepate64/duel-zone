using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM06
{
    class BlissTotemAvatarOfLuck : Creature
    {
        public BlissTotemAvatarOfLuck() : base("Bliss Totem, Avatar of Luck", 6, 5000, Race.MysteryTotem, Civilization.Nature)
        {
            AddTapAbility(new BlissTotemAvatarOfLuckEffect());
        }
    }

    class BlissTotemAvatarOfLuckEffect : OneShotEffects.FromGraveyardIntoManaZoneEffect
    {
        public BlissTotemAvatarOfLuckEffect() : base(0, 3, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BlissTotemAvatarOfLuckEffect();
        }

        public override string ToString()
        {
            return "Put up to 3 cards from your graveyard into your mana zone.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Applier.Graveyard.Cards;
        }
    }
}
