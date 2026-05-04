using Model;

namespace ViewModel
{
    public class ComplitionWindowVM : AnimatedWindowVM
    {
        public void Initialize(Gamemode gamemode)
        {
            gamemode.Ended += Show;
        }
    }
}