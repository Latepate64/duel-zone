using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    public class CrimsonHammer : Spell
    {
        public CrimsonHammer() : base("Crimson Hammer", 2, Civilization.Fire)
        {
            // Destroy 1 of your opponent's creatures that has power 2000 or less.
            Abilities.Add(new SpellAbility(new CardMovingEffect(ZoneType.BattleZone, ZoneType.Graveyard, 1, 1, true, new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(2000))));
        }
    }
}
