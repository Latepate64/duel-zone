namespace Interfaces.ContinuousEffects;

public interface IPlayerCannotChooseCreatureEffect : IContinuousEffect
{
    bool PlayerCannotChooseCreature(
        ICreature creature, IPlayerV2 player, IGame game);
}