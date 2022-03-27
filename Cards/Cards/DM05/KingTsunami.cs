using Common;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class KingTsunami : Creature
    {
        public KingTsunami() : base("King Tsunami", 12, 12000, Subtype.Leviathan, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new KingTsunamiEffect()), new StaticAbilities.TripleBreakerAbility());
        }
    }

    class KingTsunamiEffect : OneShotEffects.BounceAreaOfEffect
    {
        public KingTsunamiEffect() : base(new CardFilters.AnotherBattleZoneCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new KingTsunamiEffect();
        }

        public override string ToString()
        {
            return "Return all other creatures from the battle zone to their owners' hands.";
        }
    }
}
