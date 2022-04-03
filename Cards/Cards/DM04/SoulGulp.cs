using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM04
{
    class SoulGulp : Spell
    {
        public SoulGulp() : base("Soul Gulp", 4, Civilization.Darkness)
        {
            AddSpellAbilities(new SoulGulpEffect());
        }
    }

    class SoulGulpEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            int amount = game.BattleZone.GetCreatures(game.GetOpponent(source.Controller)).Count(x => x.HasCivilization(Civilization.Light));
            return new OneShotEffects.YourOpponentChoosesAndDiscardsCardsFromHisHandEffect(amount).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new SoulGulpEffect();
        }

        public override string ToString()
        {
            return "Your opponent chooses and discards a card from his hand for each light creature he has in the battle zone.";
        }
    }
}
