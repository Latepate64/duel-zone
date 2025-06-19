using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Effects.Continuous;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class ObsidianScarab : Engine.Creature
    {
        public ObsidianScarab() : base("Obsidian Scarab", 6, 5000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new ObsidianScarabEffect()));
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
