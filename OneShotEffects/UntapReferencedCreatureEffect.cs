using Interfaces;

namespace OneShotEffects;

public sealed class UntapReferencedCreatureEffect : OneShotEffect
{
    public UntapReferencedCreatureEffect(ICreature creature) : base()
    {
        Creature = creature;
    }

    public UntapReferencedCreatureEffect(
        UntapReferencedCreatureEffect effect) : base(effect)
    {
        Creature = effect.Creature;
    }

    public ICard Creature { get; }

    public override void Apply(IGame game)
    {
        throw new NotImplementedException();
    }

    public override IOneShotEffect Copy()
    {
        return new UntapReferencedCreatureEffect(this);
    }
}
