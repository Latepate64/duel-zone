using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class GalekTheShadowWarrior : Creature
    {
        public GalekTheShadowWarrior() : base("Galek, the Shadow Warrior", 5, 2000, Engine.Subtype.Ghost, Engine.Subtype.Human, Civilization.Darkness, Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new GalekTheShadowWarriorEffect());
        }
    }

    class GalekTheShadowWarriorEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            foreach (OneShotEffect effect in new OneShotEffect[] { new OneShotEffects.DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect(), new OneShotEffects.OpponentRandomDiscardEffect() })
            {
                effect.Apply(game, source);
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new GalekTheShadowWarriorEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's creatures that has \"blocker.\" Then your opponent discards a card at random from his hand.";
        }
    }
}
