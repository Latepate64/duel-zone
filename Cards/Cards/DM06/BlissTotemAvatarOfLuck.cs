using Common;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class BlissTotemAvatarOfLuck : Creature
    {
        public BlissTotemAvatarOfLuck() : base("Bliss Totem, Avatar of Luck", 6, 5000, Subtype.MysteryTotem, Civilization.Nature)
        {
            AddAbilities(new TapAbility(new OneShotEffects.FromGraveyardIntoManaZoneEffect(new CardFilters.OwnersManaZoneCardFilter(), 0, 3, true)));
        }
    }
}
