using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class GalekTheShadowWarrior : Creature
    {
        public GalekTheShadowWarrior() : base("Galek, the Shadow Warrior", 5, 2000, Civilization.Darkness, Civilization.Fire)
        {
            AddSubtypes(Subtype.Ghost, Subtype.Human);
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new GalekTheShadowWarriorEffect()));
        }
    }

    class GalekTheShadowWarriorEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            foreach (OneShotEffect effect in new OneShotEffect[] { new OneShotEffects.DestroyEffect(new CardFilters.OpponentsBattleZoneChoosableBlockerCreatureFilter(), 1, 1, true), new OneShotEffects.OpponentRandomDiscardEffect() })
            {
                effect.Apply(game, source);
            }
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new GalekTheShadowWarriorEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's creatures that has \"blocker.\" Then your opponent discards a card at random from his hand.";
        }
    }
}
