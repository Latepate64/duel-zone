using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

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
        public override void Apply(IGame game, IAbility source)
        {
            foreach (var effect in new OneShotEffect[] { new HideAndSeekBounceEffect(), new OpponentRandomDiscardEffect() })
            {
                effect.Apply(game, source);
            }
        }

        public override IOneShotEffect Copy()
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
        public HideAndSeekBounceEffect() : base(1, 1)
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

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id).Where(x => !x.IsEvolutionCreature);
        }
    }
}
