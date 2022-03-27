using Common;
using Engine.Abilities;

namespace Cards.Cards.DM04
{
    class CloneFactory : Spell
    {
        public CloneFactory() : base("Clone Factory", 3, Civilization.Water)
        {
            AddSpellAbilities(new CloneFactoryEffect());
        }
    }

    class CloneFactoryEffect : OneShotEffects.SelfManaRecoveryEffect
    {
        public CloneFactoryEffect() : base(0, 2, true, new CardFilters.OwnersManaZoneCardFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new CloneFactoryEffect();
        }

        public override string ToString()
        {
            return "Return up to 2 cards from your mana zone to your hand.";
        }
    }
}
