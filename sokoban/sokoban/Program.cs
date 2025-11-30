

namespace sokoban
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //------------------초기화------------------
            // 콘솔 창 초기화
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Sonkoban";
            Console.CursorVisible = false;
            Console.Clear();  // 콘솔 창 비우기

            // 게임 데이터 초기화
            
            int mapSizeMinX = 0;
            int mapSizeMinY = 0;
            int mapSizeMaxX = 12;
            int mapSizeMaxY = 12;

            // 플레이어의 초기 위치 좌표
            int playerX = 3;
            int playerY = 3;
            // 벽 위치
            int wallX = 6;
            int wallY = 5;

            // 이 스코프 안을 프레임이라고 말함
            // 알아야 하는 용어 "프레임워크" = 응용프로그램의 동작순서
            // 그리는 단계 - 키입력하는 단계 - 업데이트(갱신 데이터조작)

            // ---------------게임 루프-----------------
            while (true)
            {
                //------------------ Render -------------------------
                Console.Clear();

                // 플레이어
                Console.SetCursorPosition(playerX, playerY);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("★");

                // 벽
                Console.SetCursorPosition(wallX, wallY);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("■");

                //------------------ ProcessInput -------------------
                // 키보드 입력
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                //------------------ Update -------------------------

                int nextPlayerX = playerX;
                int nextPlayerY = playerY;

                // 플레이어 이동 처리
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    nextPlayerY = playerY + 1;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    nextPlayerY = playerY - 1;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    nextPlayerX = playerX + 1;
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    nextPlayerX = playerX - 1;
                }
                else
                {
                    continue;
                }

                // 벽 충돌

                // 벽 충돌
                bool hitWall = (nextPlayerX == wallX) && (nextPlayerY == wallY); // 

                // 맵 경계 이탈
                bool isXOutOfBounds = (nextPlayerX < mapSizeMinX || nextPlayerX > mapSizeMaxX);
                bool isYOutOfBounds = (nextPlayerY < mapSizeMinY || nextPlayerY > mapSizeMaxY);
                bool isOutOfBounds = isXOutOfBounds || isYOutOfBounds;

                // 벽과 충돌했거나 OR 경계를 벗어났다면,
                // 움직임이 막힌 상태
                bool isBlocked = hitWall || isOutOfBounds;

                // 이동 최종 결정
                // 막히지 않았을 때만 이동 가능
                if (isBlocked == false)
                {
                    playerX = nextPlayerX;
                    playerY = nextPlayerY;
                }

            }
        }

    }
}