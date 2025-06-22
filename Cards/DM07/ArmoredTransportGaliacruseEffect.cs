using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using ContinuousEffects;
using Interfaces;

namespace Cards.DM07;

public sealed class ArmoredTransportGaliacruseEffect : OneShotAreaOfEffect
{
    public ArmoredTransportGaliacruseEffect() : base()
    {
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
            new StaticAbility(new ThisCreatureCanAttackUntappedCreaturesEffect()),
            [.. GetAffectedCards(game, Ability)]));
    }

    public override IOneShotEffect Copy()
    {
        return new ArmoredTransportGaliacruseEffect();
    }

    public override string ToString()
    {
        return "Each of your fire creatures gets \"This creature can attack untapped creatures\" until the end of the turn.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id, Civilization.Fire);
    }
}
