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
            AddSpellAbilities(new HideAndSeekEffect());
        }
    }

    class HideAndSeekEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            foreach (var effect in new OneShotEffect[] { new HideAndSeekBounceEffect(), new OpponentRandomDiscardEffect() })
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

    class HideAndSeekBounceEffect : BounceEffect
    {
        public HideAndSeekBounceEffect() : base(new CardFilters.OpponentsBattleZoneChoosableNonEvolutionCreatureFilter(), 1, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new HideAndSeekBounceEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's non-evolution creatures in the battle zone and return it to his hand.";
        }
    }
}
