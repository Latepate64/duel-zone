using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class TransmogrifyEffect : OneShotEffect
{
    public TransmogrifyEffect()
    {
    }

    public TransmogrifyEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var destroyedCreature = Controller.DestroyCreatureOptionally(game, Ability);
        destroyedCreature?.Owner.RevealFromTopDeckUntilNonEvolutionCreaturePutIntoBattleZoneRestIntoGraveyard(
            game, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new TransmogrifyEffect(this);
    }

    public override string ToString()
    {
        return "You may destroy a creature. If you do, its owner reveals cards from the top of his deck until he reveals a non-evolution creature. He puts that creature into the battle zone and puts the rest of those cards into his graveyard.";
    }
}
