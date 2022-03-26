using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class ScarletSkyterror : Creature
    {
        public ScarletSkyterror() : base("Scarlet Skyterror", 8, 3000, Subtype.ArmoredWyvern, Civilization.Fire)
        {
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new ScarletSkyterrorEffect()));
        }
    }

    class ScarletSkyterrorEffect : DestroyAreaOfEffect
    {
        public ScarletSkyterrorEffect() : base(new CardFilters.BattleZoneBlockerCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ScarletSkyterrorEffect();
        }

        public override string ToString()
        {
            return "Destroy all creatures that have \"blocker.\"";
        }
    }
}
