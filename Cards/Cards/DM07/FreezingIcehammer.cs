using Common;
using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class FreezingIcehammer : Spell
    {
        public FreezingIcehammer() : base("Freezing Icehammer", 3, Civilization.Nature)
        {
            AddSpellAbilities(new FreezingIcehammerEffect());
        }
    }

    class FreezingIcehammerEffect : OneShotEffects.ManaFeedEffect
    {
        public FreezingIcehammerEffect() : base(new CardFilters.OpponentsBattleZoneChoosableCivilizationCreatureFilter(Civilization.Water, Civilization.Darkness), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new FreezingIcehammerEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's water or darkness creatures in the battle zone. Your opponent puts that creature into his mana zone.";
        }
    }
}
