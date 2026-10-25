namespace Models;

public partial class YouMayDrawCardEffect : OneShotEffect
{
    public override YouMayDrawCardEffect Copy()
    {
        return new YouMayDrawCardEffect();
    }
}
