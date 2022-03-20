using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM11
{
    class HideAndSeek : Spell
    {
        public HideAndSeek() : base("Hide and Seek", 4, Civilization.Water, Civilization.Darkness)
        {
            AddAbilities(new SpellAbility(new HideAndSeekEffect()));
        }
    }

    class HideAndSeekEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            foreach (var effect in new OneShotEffect[] { new BounceEffect(1, 1, new CardFilters.OpponentsBattleZoneChoosableNonEvolutionCreatureFilter()), new OpponentRandomDiscardEffect() })
            {
                effect.Apply(game, source);
            }
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new HideAndSeekEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's non-evolution creatures in the battle zone and return it to his hand. Then he discards a card at random from his hand.";
        }
    }
}
