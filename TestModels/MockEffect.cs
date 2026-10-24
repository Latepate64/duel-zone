using Models;

namespace TestModels;

internal class MockEffect : OneShotEffect
{
    public override MockEffect Copy()
    {
        return new MockEffect();
    }
}