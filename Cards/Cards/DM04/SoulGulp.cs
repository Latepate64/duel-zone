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
        public SoulGulpEffect()
        {
        }

        public SoulGulpEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            int amount = Game.BattleZone.GetCreatures(Applier.Opponent).Count(x => x.HasCivilization(Civilization.Light));
            Applier.Opponent.DiscardOwnCards(Ability, amount);
        }

        public override IOneShotEffect Copy()
        {
            return new SoulGulpEffect(this);
        }

        public override string ToString()
        {
            return "Your opponent chooses and discards a card from his hand for each light creature he has in the battle zone.";
        }
    }
}
