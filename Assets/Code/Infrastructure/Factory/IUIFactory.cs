
using Code.UI;
using CodeBase.Infrastructure.Services;

namespace Code.Infrastructure.Factory
{
    public interface IUIFactory : IService
    {
        Hud Hud { get; }

        Hud CreateHud();
    }
}
