namespace Interfaces.ContinuousEffects;

public interface IPlayerCannotChooseCreatureEffect : IContinuousEffect
{
    bool PlayerCannotChooseCreature(
        ICreature creature, IPlayer player, IGame game);
}