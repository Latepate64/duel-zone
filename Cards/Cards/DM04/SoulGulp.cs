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
        public override void Apply(IGame game, IAbility source)
        {
            var opponent = game.GetOpponent(source.GetController(game));
            int amount = game.BattleZone.GetCreatures(opponent.Id).Count(x => x.HasCivilization(Civilization.Light));
            opponent.DiscardOwnCards(game, source, amount);
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
