using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM11
{
    class MiraculousPlague : Spell
    {
        public MiraculousPlague() : base("Miraculous Plague", 7, Civilization.Water, Civilization.Darkness)
        {
            AddSpellAbilities(new MiraculousPlagueEffect());
        }
    }

    class MiraculousPlagueEffect : OneShotEffect
    {
        public MiraculousPlagueEffect()
        {
        }

        public override void Apply(IGame game)
        {
            var creatures = Applier.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(game, Applier), 2, 2, ToString());
            var toHand = Applier.Opponent.ChooseCard(creatures, ToString());
            game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, toHand);
            game.Destroy(Ability, creatures.Where(x => x != toHand).ToArray());

            var cards = Applier.ChooseCards(Applier.Opponent.ManaZone.Cards, 2, 2, ToString());
            var manaToHand = Applier.Opponent.ChooseCard(cards, ToString());
            game.Move(Ability, ZoneType.ManaZone, ZoneType.Hand, manaToHand);
            game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, cards.Where(x => x != manaToHand).ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new MiraculousPlagueEffect();
        }

        public override string ToString()
        {
            return "Choose 2 of your opponent's creatures in the battle zone. Your opponent chooses one of them, puts it into his hand, and destroys the other one. Then choose 2 cards in your opponent's mana zone. Your opponent chooses one of them, puts it into his hand, and puts the other one into his graveyard.";
        }
    }
}
