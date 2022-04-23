using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class ObsidianScarab : Creature
    {
        public ObsidianScarab() : base("Obsidian Scarab", 6, 5000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(3000);
            AddDoubleBreakerAbility();
            AddWhenThisCreatureIsDestroyedAbility(new ObsidianScarabEffect());
        }
    }

    class ObsidianScarabEffect : YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect
    {
        public ObsidianScarabEffect(YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect effect) : base(effect)
        {
        }

        public ObsidianScarabEffect() : base("Obsidian Scarab")
        {
        }

        public override IOneShotEffect Copy()
        {
            return new AmbushScorpionEffect(this);
        }
    }
}
