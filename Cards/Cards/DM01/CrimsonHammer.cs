using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    public class CrimsonHammer : Spell
    {
        public CrimsonHammer() : base("Crimson Hammer", 2, Common.Civilization.Fire)
        {
            // Destroy 1 of your opponent's creatures that has power 2000 or less.
            Abilities.Add(new SpellAbility(new DestroyEffect(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(2000), 1, 1, true)));
        }
    }
}
