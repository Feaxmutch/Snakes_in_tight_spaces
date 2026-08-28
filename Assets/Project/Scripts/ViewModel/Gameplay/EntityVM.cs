using Model;
using Other;

namespace ViewModel
{
    public class EntityVM : GridObjectVM
    {
        public EntityVM() : base() { }

        public byte GroopId { get; private set; }

        public void Initialize(byte groopId)
        {
            GroopId = groopId;
        }
    }
}