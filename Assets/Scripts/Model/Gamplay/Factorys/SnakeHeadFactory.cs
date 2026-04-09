using Other;
using System.Collections.Generic;

namespace Model
{
    public class SnakeHeadFactory : ColoredObjectFactory
    {
        public SnakeHead Create(Color color, float speed, List<SnakeBody> snakeBodies)
        {
            SnakeHead snakeHead = Create<SnakeHead>(color);
            snakeHead.Initialize(speed, snakeBodies);
            return snakeHead;
        }
    }
}