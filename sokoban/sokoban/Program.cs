

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

            // 플레이어의 초기 위치
            int playerX = 3;
            int playerY = 3;
            // 벽 위치
            int wallX = 6;
            int wallY = 5;
            // 상자 위치
            int boxX = 7;
            int boxY = 3;
            // 골 위치
            int goalX = 12;
            int goalY = 12;

            // 이 스코프 안을 프레임이라고 말함
            // 알아야 하는 용어 "프레임워크" = 응용프로그램의 동작순서
            // 그리는 단계 - 키입력하는 단계 - 업데이트(갱신 데이터조작)

            // ---------------게임 루프-----------------
            while (true)
            {


                //------------------ Render -------------------------
                Console.Clear();
                
                if (boxX == goalX && boxY == goalY)
                {
                    Console.SetCursorPosition(boxX, boxY);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("@");

                    Console.SetCursorPosition(6, 6);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("Clear!");
                }

                // 플레이어
                Console.SetCursorPosition(playerX, playerY);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("P");

                // 벽
                Console.SetCursorPosition(wallX, wallY);
                Console.ForegroundColor = ConsoleColor.DarkRed; 
                Console.Write("#");

                // 상자 
                Console.SetCursorPosition(boxX, boxY);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("@");

                // 골
                Console.SetCursorPosition(goalX, goalY);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("O");

                //------------------ ProcessInput -------------------
                // 키보드 입력
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                //------------------ Update -------------------------
                
                // 다음 플레이어 위치 임시 변수
                int nextPlayerX = playerX;
                int nextPlayerY = playerY;
               
                // 다음 박스 위치 임시 변수
                int nextBoxX = boxX;
                int nextBoxY = boxY;

                // 충돌 및 이동 가능 여부 플래그
                bool isBlocked = false;
                bool isPushingBox = false;
               

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

                // 이동 방향 계산
                // nextPlayerX/Y가 갱신된 후에만 정확한 방향(1, -1, 0)을 얻을 수 있습니다
                int moveX = nextPlayerX - playerX;
                int moveY = nextPlayerY - playerY;

                // 상자와의 충돌 확인
                bool hitBox = (nextPlayerX == boxX) && (nextPlayerY == boxY);

                if (hitBox)
                {
                    // 4-1. 상자가 밀릴 다음 위치 계산
                    nextBoxX = boxX + moveX;
                    nextBoxY = boxY + moveY;

                    // 4-2. 상자가 밀릴 다음 위치가 벽 또는 경계 밖인지 확인 (추가)
                    bool boxHitsWall = (nextBoxX == wallX) && (nextBoxY == wallY);

                    bool boxIsOutOfBounds = (nextBoxX < mapSizeMinX || nextBoxX > mapSizeMaxX ||
                                             nextBoxY < mapSizeMinY || nextBoxY > mapSizeMaxY);

                    // 상자가 막히면 isBlocked = true, 아니면 상자 밀기 허용
                    if (boxHitsWall || boxIsOutOfBounds)
                    {
                        isBlocked = true;
                    }
                    else
                    {
                        isPushingBox = true;
                    }
                }
                else
                {
                    // 상자에 부딪히지 않았을 경우, 벽/경계 충돌만 확인
                    // 벽 충돌
                    bool hitWall = (nextPlayerX == wallX) && (nextPlayerY == wallY);
                    // 맵 경계 이탈
                    bool isXOutOfBounds = (nextPlayerX < mapSizeMinX || nextPlayerX > mapSizeMaxX);
                    bool isYOutOfBounds = (nextPlayerY < mapSizeMinY || nextPlayerY > mapSizeMaxY);
                    bool isOutOfBounds = isXOutOfBounds || isYOutOfBounds;
                    //벽과 충돌했거나 OR 경계를 벗어났다면, 움직임이 막힌 상태
                    isBlocked = hitWall || isOutOfBounds;
                }

                // 이동 최종 결정
                // 막히지 않았을 때만 이동 가능
                if (isBlocked == false)
                {
                    playerX = nextPlayerX;
                    playerY = nextPlayerY;

                    // 상자를 밀었을 경우 상자도 이동
                    if (isPushingBox)
                    {
                        boxX = nextBoxX;
                        boxY = nextBoxY;     
                    }
                }

               
                

            }
        }

    }
}