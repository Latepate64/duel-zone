using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    public class SupersonicJetPack : Spell
    {
        public SupersonicJetPack() : base("Supersonic Jet Pack", 1, Civilization.Fire)
        {
            // One of your creatures in the battle zone gets "speed attacker" until the end of the turn. (It doesn't get summoning sickness.)
            Abilities.Add(new SpellAbility(new GrantAbilityChoiceEffect(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true, new SpeedAttackerAbility())));
        }
    }
}
