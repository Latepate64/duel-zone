using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class Transmogrify : Spell
    {
        public Transmogrify() : base("Transmogrify", 3, Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new TransmogrifyEffect());
        }
    }

    public class TransmogrifyEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var controller = source.GetController(game);
            var card = controller.ChooseCardOptionally(game.BattleZone.GetChoosableCreaturesControlledByAnyone(game, controller.Id), ToString());
            if (card != null)
            {
                game.Destroy(source, card);
                ApplyAfterDestroy(game, source, game.GetOwner(card));
            }
            return null;
        }

        public static void ApplyAfterDestroy(IGame game, IAbility source, IPlayer player)
        {
            var index = player.DeckCards.FindLastIndex(x => x.IsNonEvolutionCreature);
            var revealed = player.DeckCards.Skip(index).ToArray();
            player.Reveal(game, revealed);
            var creature = index != -1 ? revealed.FirstOrDefault() : null;
            var toGraveyard = revealed.Where(x => x != creature).ToArray();
            if (creature != null)
            {
                game.Move(source, ZoneType.Deck, ZoneType.BattleZone, creature);
            }
            game.Move(source, ZoneType.Deck, ZoneType.Graveyard, toGraveyard);
        }

        public override IOneShotEffect Copy()
        {
            return new TransmogrifyEffect();
        }

        public override string ToString()
        {
            return "You may destroy a creature. If you do, its owner reveals cards from the top of his deck until he reveals a non-evolution creature. He puts that creature into the battle zone and puts the rest of those cards into his graveyard.";
        }
    }
}
