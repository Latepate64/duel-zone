using Engine;
using Engine.Abilities;
using System.Linq;
using Interfaces;

namespace OneShotEffects;

public sealed class AuraPegasusEffect : OneShotEffect
{
    public AuraPegasusEffect()
    {
    }

    public AuraPegasusEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var cards = Controller.RevealTopCardsOfDeck(1, game);
        game.Move(Ability, ZoneType.Deck, cards.All(x => x is Creature c && c.IsNonEvolutionCreature)
            ? ZoneType.BattleZone : ZoneType.Hand, [.. cards]);
    }

    public override IOneShotEffect Copy()
    {
        return new AuraPegasusEffect(this);
    }

    public override string ToString()
    {
        return "Reveal the top card of your deck. If it's a non-evolution creature, put it into battle zone. Otherwise, put it to your hand.";
    }
}
