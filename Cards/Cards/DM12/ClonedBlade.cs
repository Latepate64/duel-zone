using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM12
{
    class ClonedBlade : Spell
    {
        public ClonedBlade() : base("Cloned Blade", 5, Civilization.Fire)
        {
            AddSpellAbilities(new ClonedBladeEffect(Name));
        }
    }

    class ClonedBladeEffect : ClonedEffect
    {
        public ClonedBladeEffect(string name) : base(name)
        {
        }

        public ClonedBladeEffect(ClonedBladeEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game, IAbility source)
        {
            var creatures = source.GetController(game).ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id).Where(x => x.Power <= 3000), 1, GetAmount(game), ToString());
            game.Destroy(source, creatures.ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new ClonedBladeEffect(this);
        }

        public override string ToString()
        {
            return "Choose an opponent's creature in the battle zone that has power 3000 or less. Then, for each Cloned Blade in each graveyard, you may choose another opponent's creature in the battle zone that has power 3000 or less. Destroy all those creatures.";
        }
    }
}
