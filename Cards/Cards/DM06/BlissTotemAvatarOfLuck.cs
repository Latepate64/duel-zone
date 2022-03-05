using Common;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class BlissTotemAvatarOfLuck : Creature
    {
        public BlissTotemAvatarOfLuck() : base("Bliss Totem, Avatar of Luck", 6, Civilization.Nature, 5000, Subtype.MysteryTotem)
        {
            Abilities.Add(new TapAbility(new OneShotEffects.FromGraveyardIntoManaZoneEffect(new CardFilters.OwnersManaZoneCardFilter(), 0, 3, true)));
        }
    }
}
