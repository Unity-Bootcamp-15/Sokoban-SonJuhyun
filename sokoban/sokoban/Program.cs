

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
            Console.Clear();

            // 게임 데이터 초기화
            // 플레이어의 위치 좌표
            int mapSizeMinX = 0;
            int mapSizeMinY = 0;
            int mapSizeMaxX = 20;
            int mapSizeMaxY = 10;


            int playerX = 5;
            int playerY = 10;
            int wallX = 20;
            int wallY = 10;

            // 이 스코프 안을 프레임이라고 말함
            // 알아야 하는 용어 "프레임워크" = 응용프로그램의 동작순서
            // 그리는 단계 - 키입력하는 단계 - 업데이트(갱신 데이터조작)

            // ---------------게임 루프-----------------
            while (true)
            {
                //------------------ Render -------------------------
                Console.Clear();
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("★");

                //------------------ ProcessInput -------------------
                // 키보드 입력
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                //------------------ Update -------------------------
                // 플레이어 이동 처리
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    playerY = Math.Max(mapSizeMaxY, playerY + 1);
                }

                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    playerY = Math.Max(mapSizeMinY, playerY - 1);
                }

                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    playerX = Math.Max(mapSizeMaxX, playerX + 1);
                }

                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    playerX = Math.Max(mapSizeMaxY, playerX - 1);
                }

                bool isSamePlayerXandWallX = playerX == wallX;
                bool isSamePlayerXandWallY = playerY == wallY;

            }
        }

    }
}
