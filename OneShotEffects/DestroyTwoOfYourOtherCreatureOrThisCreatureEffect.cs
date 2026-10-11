using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Destroy 2 of your other creatures or destroy this creature.
/// </summary>
public sealed class DestroyTwoOfYourOtherCreatureOrThisCreatureEffect
    : OneShotEffect
{
    private readonly ICardFilter filter;

    public DestroyTwoOfYourOtherCreatureOrThisCreatureEffect(ICardFilter filter)
    {
        this.filter = filter;
    }

    public DestroyTwoOfYourOtherCreatureOrThisCreatureEffect(
        DestroyTwoOfYourOtherCreatureOrThisCreatureEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        // Destroy 2 of your other creatures or destroy this creature.
        var creatures = game.BattleZone.GetCreatures(Ability.Controller.Id);
        var thisCreature = creatures.SingleOrDefault(x => x == Ability.Source);
        if (thisCreature == null)
        {
            game.Destroy(
                Ability,
                [.. game.BattleZone.GetOtherCreaturesControlledByPlayer(
                    (ICreature)Source!, filter)]);
        }
        else if (creatures.Count(x => x != Ability.Source) < 2)
        {
            game.Move(Ability, ZoneType.BattleZone, ZoneType.Graveyard, thisCreature);
        }
        else
        {
            var selection = Controller.ChooseCards(creatures, 1, 2, ToString());
            if ((selection.Count() == 1 && selection.Single().Id == thisCreature.Id)
            || (selection.Count() == 2 && selection.All(x => x.Id != thisCreature.Id)))
            {
                game.Move(Ability, ZoneType.BattleZone, ZoneType.Graveyard, [.. selection]);
            }
            else
            {
                // Selection was illegal, try selecting again.
                Apply(game);
            }
        }
    }

    public override IOneShotEffect Copy()
    {
        return new DestroyTwoOfYourOtherCreatureOrThisCreatureEffect(this);
    }
}
