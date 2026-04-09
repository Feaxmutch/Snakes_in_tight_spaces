using Model;
using Other;

namespace ViewModel
{
    public class ComplitionWindowVM : DefaultWindowVM
    {
        public ComplitionWindowVM() : base()
        {

        }

        public void Initialize(Gamemode gamemode)
        {
            gamemode.Ended += Show;
        }
    }
}