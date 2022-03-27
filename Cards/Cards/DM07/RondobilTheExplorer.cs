using Common;
using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class RondobilTheExplorer : Creature
    {
        public RondobilTheExplorer() : base("Rondobil, the Explorer", 6, 5000, Subtype.Gladiator, Civilization.Light)
        {
            AddAbilities(new TapAbility(new RondobilTheExplorerEffect()));
        }
    }

    class RondobilTheExplorerEffect : OneShotEffects.CardMovingChoiceEffect
    {
        public RondobilTheExplorerEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true, ZoneType.BattleZone, ZoneType.ShieldZone)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new RondobilTheExplorerEffect();
        }

        public override string ToString()
        {
            return "Add one of your creatures from the battle zone to your shields face down.";
        }
    }
}
