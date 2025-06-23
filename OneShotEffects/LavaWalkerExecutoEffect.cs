using ContinuousEffects;
using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace OneShotEffects;

public sealed class LavaWalkerExecutoEffect : CreatureSelectionEffect, IPowerable
{
    public int Power { get; }

    public LavaWalkerExecutoEffect(LavaWalkerExecutoEffect effect) : base(effect)
    {
        Power = effect.Power;
    }

    public LavaWalkerExecutoEffect(int power) : base(1, 1, true)
    {
        Power = power;
    }

    public override IOneShotEffect Copy()
    {
        return new LavaWalkerExecutoEffect(this);
    }

    public override string ToString()
    {
        return $"One of your fire creatures in the battle zone gets +{Power} power until the end of the turn.";
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
    {
        game.AddContinuousEffects(Ability, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(
            Power, cards));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id, Civilization.Fire);
    }
}
