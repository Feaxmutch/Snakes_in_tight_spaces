using Other;
using System.Collections.Generic;

namespace Model
{
    public class SnakeHeadFactory : EntityFactory
    {
        public SnakeHead Create(byte groopId, float speed, List<SnakeBody> snakeBodies)
        {
            SnakeHead snakeHead = Create<SnakeHead>(groopId);
            snakeHead.Initialize(speed, snakeBodies);
            return snakeHead;
        }
    }
}