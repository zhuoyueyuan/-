using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace 血色麦浪
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 设置画面大小
            Console.CursorVisible = false;
            int w = 80;
            int h = 40;
            Console.SetWindowSize(w+2, h+1);
            Console.SetBufferSize(w+2, h+1);
            #endregion
            #region 角色设置
            #region 玩家设置//需要重新设置
            int playerX = 10;
            int playerY = 15;
            int playerAtkMin = 8;
            int playerAtkMax = 12;
            int playerHp = 100;
            string playerIcon = "★";
            ConsoleColor playerColor = ConsoleColor.Yellow;
            char playerInput;
            #endregion
            #region NPC设置//需要重新设置
            int NPCX = 4;
            int NPCY = 5;
            string NPCIcon = "？";
            ConsoleColor NPCColor = ConsoleColor.Yellow;
            #endregion
            #region 杀手设置//需要重新设置
            int killerX = 40;
            int killerY = 10;
            int killerAtkMin = 8;
            int killerAtkMax = 12;
            int killerHp = 100;
            string killerIcon = "★";
            ConsoleColor killerColor = ConsoleColor.Yellow;
            #endregion
            #endregion
            #region 场景设置
            string gameOverInfo = "0";
            int sumAtkMin = 0;
            int sumAtkMax = 0;
            int sumHp = 0;
            bool shuxingfenpei = false;
            int HP = 0;
            int attackMin = 0;
            int attackMax = 0;
            bool l = false;
            int tiShi = 0;
            string passWord = "";
            Random tiShiMap = new Random();
            int tiShiDiTu = tiShiMap.Next(1, 5);//随机生成隐藏点
            bool tiShiDiTu1 = false;
            bool tiShiDiTu2 = false;
            bool tiShiDiTu3 = false;
            bool tiShiDiTu4 = false;
            bool iskiller = false;//杀手是否现身
            bool isKiller1 = false;
            bool isKiller2 = false;
            bool isKiller3 = false;
            bool isKiller4 = false;
            int nowSceneID = 0;//改变游戏场景的变量
                               //0：开始界面
                               //1：第一个游戏界面；2：第二个游戏界面；3：第三个游戏界面；4：第四个游戏界面
                               //5：战斗界面
                               //6：结束界面
            #endregion

            while (true)
            {
                bool killerChange = false;
                if (killerChange == false)
                {
                    killerAtkMin = 8;
                    killerAtkMax = 12;
                    killerHp = 100;
                    int killerAtkMinPP = 0;
                    int killerAtkMaxPP = 0;
                    int killerHpPP = 0;
                    Random killerAtkMinP = new Random();
                    Random killerAtkMaxP = new Random();
                    Random killerHpP = new Random();
                    killerAtkMinPP = killerAtkMinP.Next(0, 20);
                    killerAtkMaxPP = killerAtkMinP.Next(0, 20);
                    killerHpPP = killerHpP.Next(0, 20);
                    killerAtkMin = killerAtkMin + killerAtkMinPP;
                    killerAtkMax = killerAtkMax + killerAtkMaxPP;
                    killerHp = killerHp + killerHpPP;
                    if (killerAtkMinPP + killerAtkMaxPP + killerHpPP == 20 && killerAtkMin < killerAtkMax)
                    {
                        killerChange = true; 
                        break;
                    }
                }
            }
            while (true) 
            {
                bool isTalk = false;
                Console.ForegroundColor = ConsoleColor.Red;
                switch (nowSceneID)
                {
                    case 0://游戏开始界面
                        #region 游戏开始界面
                        playerX = 10;
                        playerY = 15;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(w / 2 - 8, 8);
                        Console.Write("血   色   麦   浪");//标题
                        Console.SetCursorPosition(w / 2 - 20, h - 28);
                        Console.WriteLine("丰收季的麦田镇，麦田实验员被发现死于家中。");
                        Console.SetCursorPosition(w / 2 - 16, h - 26);
                        Console.WriteLine("胸口插着收割刀，刀柄缠着金黄色麦穗。");
                        Console.SetCursorPosition(w / 2 - 18, h - 24);
                        Console.WriteLine("四名嫌疑人各怀动机，你顶着烈日展开调查。");
                        int startSel = 0;
                        while (true)
                        {
                            bool isQuitStart = false;
                            Console.SetCursorPosition(w / 2 - 8, 25);
                            Console.ForegroundColor = startSel == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("开始游戏（按L确认）");
                            Console.SetCursorPosition(w / 2 - 4, 30);
                            Console.ForegroundColor = startSel == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("结束游戏");
                            char input = Console.ReadKey(true).KeyChar;//判断当前选项
                            switch (input)
                            {
                                case 'w':
                                case 'W':
                                    startSel = 0;
                                    break;
                                case 's':
                                case 'S':
                                    startSel = 1;
                                    break;
                                case 'l':
                                case 'L':
                                    if (startSel == 0)
                                    {
                                        nowSceneID = 1;
                                        isQuitStart = true;
                                    }
                                    else
                                    {
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                            if (isQuitStart)
                            {
                                break;
                            }
                        }
                        break;
                    #endregion
                    case 1://游戏场景一
                        Console.Clear();
                        #region 场景一边界
                        #region 横向
                        for (int i = w - 80; i < w; i = i + 2) //顶部
                        {
                            Console.SetCursorPosition(i, h - 40);
                            Console.Write("■");
                        }
                        for (int i = w - 80; i < w - 60; i = i + 2)//底部左侧
                        {
                            Console.SetCursorPosition(i, h);
                            Console.Write("■");
                        }
                        for (int i = w - 40; i < w - 16; i = i + 2) //底部右侧
                        {
                            Console.SetCursorPosition(i, h);
                            Console.Write("■");
                        }
                        #endregion
                        #region 纵向
                        for (int i = h - 40; i < h - 30; i = i + 1)
                        {
                            Console.SetCursorPosition(w - 80, i);//左侧上部
                            Console.Write("■");
                        }
                        for (int i = h - 20; i >= h - 20 && i < h; i = i + 1)//左侧下部
                        {
                            Console.SetCursorPosition(w - 80, i);
                            Console.Write("■");
                        }
                        for (int i = h - 40; i < h - 30; i = i + 1)//右侧上部
                        {
                            Console.SetCursorPosition(w - 2, i);
                            Console.Write("■");
                        }
                        for (int i = h - 20; i < h - 10; i = i + 1)//右侧下部
                        {
                            Console.SetCursorPosition(w - 2, i);
                            Console.Write("■");
                        }
                        #endregion
                        #region 斜向
                        for (int x = w - 2, y = h - 10; x > w - 22 && y < h; x = x - 2, y = y + 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write("■");
                        }
                        #endregion
                        #endregion
                        #region 场景一装饰
                        for (int x = 30, y = 40; y > 15; x = 70 - 3 / 2 * y, y = y - 1) //道路右
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.SetCursorPosition(x, y);
                            Console.Write("`");
                        }
                        for (int x = 2, y = 17; x < 80; x = x + 2) //道路左
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.SetCursorPosition(x, y);
                            Console.Write("`");
                        }
                        for (int x = 2; x < w - 35; x = x + 2)//上树左
                        {
                            for (int y = 1; y < 15; y = y + 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.SetCursorPosition(x, y);
                                Console.Write("木");
                            }
                        }
                        for (int x = 2; x < 20; x = x + 2)//下树左
                        {
                            for (int y = 22; y < 40; y = y + 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.SetCursorPosition(x, y);
                                Console.Write("木");
                            }
                        }
                        if (tiShiDiTu1 == true) //地图一新增提示点
                        {
                            for (int x = 2, y = 21; ;)
                            {
                                Console.SetCursorPosition(x, y);
                                Console.Write("▲");
                                break;
                            }
                        }
                        #endregion
                        #region 场景一NPC设置
                        Console.ForegroundColor = NPCColor;
                        Console.SetCursorPosition(60, 10);
                        Console.Write(NPCIcon);
                        #endregion
                        int duiHuaXuHao = 0;
                        while (true)
                        {
                            #region #场景一玩家移动
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write(playerIcon);
                            playerInput = Console.ReadKey(true).KeyChar;
                            if (isTalk)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                switch (duiHuaXuHao)
                                {
                                    case 1:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("你：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("我是来调查杀人案的。");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("报告上说你半年前卖给killer一批除草剂");
                                                duiHuaXuHao = 2;
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("独居药剂师：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("他定制了加强版草铵膦。");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("但配方被我改良过，绝对安全！");
                                                duiHuaXuHao = 3;
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("你：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("为什么死者书房，");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("找到的药剂瓶写着原始配方？");
                                                duiHuaXuHao = 4;
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("独居药剂师：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("那……我不知道。");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("他是农场研究员，可能也在研究除草剂配方。");
                                                duiHuaXuHao = 5;
                                            }
                                            break;
                                        }
                                    case 5:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                isTalk = false;
                                                for (int x = 0; x <= 80; x = x + 1)
                                                {
                                                    for (int y = 20; y <= 40; y = y + 1)
                                                    {
                                                        Console.SetCursorPosition(x, y);
                                                        Console.Write(" ");
                                                    }
                                                }
                                                for (int i = w - 80; i < w - 60; i = i + 2)//底部左侧
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(i, h);
                                                    Console.Write("■");
                                                }
                                                for (int i = w - 40; i < w - 16; i = i + 2) //底部右侧
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(i, h);
                                                    Console.Write("■");
                                                }
                                                for (int i = h - 20; i >= h - 20 && i < h; i = i + 1)//左侧下部
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(w - 80, i);
                                                    Console.Write("■");
                                                }
                                                for (int i = h - 20; i < h - 10; i = i + 1)//右侧下部
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(w - 2, i);
                                                    Console.Write("■");
                                                }
                                                for (int x = w - 2, y = h - 10; x > w - 22 && y < h; x = x - 2, y = y + 1)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write("■");
                                                }
                                                for (int x = 30, y = 40; y > 15; x = 70 - 3 / 2 * y, y = y - 1) //道路右
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write("`");
                                                }
                                                for (int x = 2; x < 20; x = x + 2)//下树左
                                                {
                                                    for (int y = 22; y < 40; y = y + 1)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                        Console.SetCursorPosition(x, y);
                                                        Console.Write("木");
                                                    }
                                                }
                                                duiHuaXuHao = 1;
                                            }
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (playerInput)
                                {
                                    case 'w':
                                    case 'W':
                                        playerY = playerY - 1;
                                        Console.SetCursorPosition(playerX, playerY + 1);
                                        Console.Write(" ");
                                        for (int x = 30, y = 40; y > 15; x = 70 - 3 / 2 * y, y = y - 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 2, y = 17; x < 80; x = x + 2) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if (playerX == 60 && playerY == 10)
                                        {
                                            playerY = playerY + 1;
                                        }
                                        break;
                                    case 'a':
                                    case 'A':
                                        playerX = playerX - 2;
                                        Console.SetCursorPosition(playerX + 2, playerY);
                                        Console.Write(" ");
                                        for (int x = 30, y = 40; y > 15; x = 70 - 3 / 2 * y, y = y - 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 2, y = 17; x < 80; x = x + 2) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if (playerX == 60 && playerY == 10)
                                        {
                                            playerX = playerX + 2;
                                        }
                                        break;
                                    case 's':
                                    case 'S':
                                        playerY = playerY + 1;
                                        Console.SetCursorPosition(playerX, playerY - 1);
                                        Console.Write(" ");
                                        for (int x = 30, y = 40; y > 15; x = 70 - 3 / 2 * y, y = y - 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 2, y = 17; x < 80; x = x + 2) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if (playerX == 60 && playerY == 10)
                                        {
                                            playerY = playerY - 1;
                                        }
                                        break;
                                    case 'd':
                                    case 'D':
                                        playerX = playerX + 2;
                                        Console.SetCursorPosition(playerX - 2, playerY);
                                        Console.Write(" ");
                                        for (int x = 30, y = 40; y > 15; x = 70 - 3 / 2 * y, y = y - 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 2, y = 17; x < 80; x = x + 2) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if (playerX == 60 && playerY == 10)
                                        {
                                            playerX = playerX - 2;
                                        }
                                        break;
                                    case 'l':
                                    case 'L':
                                        if (((playerX == 58 || playerX == 62) && playerY == 10) || ((playerY == 9 || playerY == 11) && playerX == 60))
                                        {
                                            for (int x = 10, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 70, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 25, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 40, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 12; x < 70; x = x + 2)
                                            {
                                                for(int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            for (int x = 13; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            int a = 16, b = 28; 
                                            Console.SetCursorPosition(a, b);
                                            Console.Write("独居药剂师：（按L继续对话）");
                                            a = 20;
                                            b = 32;
                                            Console.SetCursorPosition(a, b);
                                            Console.Write("来点药祛湿吧，先生。");
                                            isTalk = true;//开启对话
                                            duiHuaXuHao = 1;
                                            isKiller1 = true;
                                        }
                                        else if (tiShiDiTu == 1 && playerX ==2 && playerY ==21)
                                        {
                                            for (int x = 10, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 70, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 25, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 40, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 12; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            for (int x = 13; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            int a = 16, b = 28;
                                            Console.SetCursorPosition(a, b);
                                            Console.Write("密码提示信息:（按L继续对话）");
                                            a = 20;
                                            b = 32;
                                            Console.SetCursorPosition(a, b);
                                            Console.Write("不止是一个字");
                                            isTalk = true;
                                            duiHuaXuHao = 5;
                                        }
                                        break;
                                }
                            }
                            //上下阻挡玩家移动
                            if (playerY == h - 40)
                            {
                                playerY = playerY + 1;
                            }
                            else if (playerY == h && (playerX > w - 80 && playerX < w - 60) || playerY == h && (playerX > w - 41 && playerX < w - 20))
                            {
                                playerY = playerY - 1;
                            }
                            else if (playerY == 14 && (playerX >= 2 && playerX < 45) )
                            {
                                playerY = playerY + 1;
                            }
                            else if (playerX >= 2 && playerX < 20 && playerY == 22)
                            {
                                playerY = playerY - 1;
                            }
                            //左右阻挡玩家移动
                            else if (playerX == w - 80)
                            {
                                playerX = playerX + 2;
                            }
                            else if (playerX == w - 2 && ((playerY > h - 40 && playerY < h - 30) || (playerY > h - 21 && playerY < h - 10)))
                            {
                                playerX = playerX - 2;
                            }
                            else if(playerY >= 1 && playerY < 14 && playerX == 44) 
                            {
                                playerX = playerX + 2;
                            }
                            else if(playerY >22 && playerY < 40 && playerX == 18)
                            {
                                playerX = playerX + 2;
                            }
                            //斜向阻挡玩家移动
                            else if ((playerX > w - 22 && playerX < w) && (playerY < h && playerY > h - 11) && (playerX == 138 - 2 * playerY))
                            {
                                playerX = playerX - 2;
                                playerY = playerY - 1;
                            }
                            //右侧切换区域
                            if (playerX == w - 2 && ((playerY >= h - 30 && playerY < h - 20) || (playerY < h && playerY > h - 10)))
                            {
                                nowSceneID = 2;
                                playerX = w - 78;
                                break;
                            }
                            //下侧切换区域
                            else if (playerY == h && ((playerX >= w - 60 && playerX < w - 40) || (playerX < w - 2 && playerX > w - 60))) 
                            {
                                nowSceneID = 3;
                                playerY = h - 39;
                                break;
                            }
                            #endregion
                        }
                        break;
                    case 2://游戏场景二
                        Console.Clear();
                        #region 场景二边界
                        #region 横向
                        for (int i = w - 80; i < w - 20; i = i + 2) //顶部
                        {
                            Console.SetCursorPosition(i, h - 40);
                            Console.Write("■");
                        }
                        for (int i = w - 60; i >= w - 60 && i < w - 40; i = i + 2) //底部左侧
                        {
                            Console.SetCursorPosition(i, h);
                            Console.Write("■");
                        }
                        for (int i = w - 20; i >= w - 20 && i < w; i = i + 2)//底部右侧
                        {
                            Console.SetCursorPosition(i, h);
                            Console.Write("■");
                        }
                        #endregion
                        #region 纵向
                        for (int i = h - 40; i < h - 30; i = i + 1)
                        {
                            Console.SetCursorPosition(w - 80, i);//左侧上部
                            Console.Write("■");
                        }
                        for (int i = h - 20; i >= h - 20 && i < h - 10; i = i + 1)//左侧下部
                        {
                            Console.SetCursorPosition(w - 80, i);
                            Console.Write("■");
                        }
                        for (int i = h - 30; i >= h - 30 && i < h; i = i + 1) //右侧
                        {
                            Console.SetCursorPosition(w - 2, i);
                            Console.Write("■");
                        }
                    #endregion
                        #region 斜向
                        for (int x = w - 20, y = h - 40; x < w && y < h - 10; x = x + 2, y = y + 1) //右侧
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write("■");
                        }
                        for (int x = w - 80, y = h - 10; x < w - 60 && y < h; x = x + 2, y = y + 1) //左侧
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write("■");
                        }
                        #endregion
                        #endregion
                        #region 场景二 装饰
                        for (int x = 62; x < w; x = x + 2) //海
                        {
                            for (int y = 0; y < h - 30; y = y + 1)
                            {
                                if (x > 2 * y + 60)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.SetCursorPosition(x, y);
                                    Console.Write("~");
                                }
                            }
                        }
                        for (int x = 2; x < w - 55; x = x + 2)//上树左
                        {
                            for (int y = 1; y < h - 30; y = y + 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.SetCursorPosition(x, y);
                                Console.Write("木");
                            }
                        }
                        for (int x = 24; x < w - 35; x = x + 2)//上树中
                        {
                            for (int y = 1; y < h - 25; y = y + 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.SetCursorPosition(x, y);
                                Console.Write("木");
                            }
                        }
                        for (int x = 44; x < w - 25; x = x + 2)//上树右
                        {
                            for (int y = 1; y < h - 35; y = y + 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.SetCursorPosition(x, y);
                                Console.Write("木");
                            }
                        }
                        for (int x = 44; x < w - 25; x = x + 2) //上树右
                        {
                            for (int y = 5; y < h - 30; y = y + 1)
                            {
                                if (x < 65 - 2 * y)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.SetCursorPosition(x, y);
                                    Console.Write("木");
                                }
                            }
                        }
                        for (int x = 0, y = 17; x < 50; x = x + 2) //道路左
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.SetCursorPosition(x, y);
                            Console.Write("`");
                        }
                        for (int x = 50, y = 17; y < 40; y = y + 1) //道路下
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.SetCursorPosition(x, y);
                            Console.Write("`");
                        }
                        for (int x = 50, y = 17; y > 6; x = 83 - 2 * y, y = y - 1) //道路右
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.SetCursorPosition(x, y);
                            Console.Write("`");
                        }
                        for (int x = 58; x < w - 2; x = x + 2) //右树
                        {
                            for (int y = 15; y < h - 1; y = y + 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.SetCursorPosition(x, y);
                                Console.Write("木");
                            }
                        }
                        for (int x = 2; x < 18; x = x + 2) //左石
                        {
                            for (int y = 20; y < h - 10; y = y + 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.SetCursorPosition(x, y);
                                Console.Write("石");
                            }
                        }
                        for (int x = 20; x < 40; x = x + 2) //下石
                        {
                            for (int y = 30; y < h; y = y + 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.SetCursorPosition(x, y);
                                Console.Write("石");
                            }
                        }
                        if (tiShiDiTu2 == true) //地图二新增提示点
                        {
                            for (int x = 76, y = 39; ;)
                            {
                                Console.SetCursorPosition(x, y);
                                Console.Write("▲");
                                break;
                            }
                        }
                        #endregion
                        #region 场景二NPC设置
                        Console.ForegroundColor = NPCColor;
                        Console.SetCursorPosition(30, 25);
                        Console.Write(NPCIcon);
                        Console.SetCursorPosition(60, 8);
                        Console.Write(NPCIcon);
                        #endregion
                        duiHuaXuHao = 1;
                        while (true)
                        {
                            #region #场景二玩家移动
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (isTalk && playerY > 25)
                            {
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write(" ");
                            }
                            else if(isTalk && playerY == 25)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write("口");
                            }
                            else
                            {
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write(playerIcon);
                            }
                            playerInput = Console.ReadKey(true).KeyChar;
                            if (isTalk)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                switch (duiHuaXuHao)
                                {
                                    case 1:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("你：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("什么证据？");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("这里不全都是石头吗？");
                                                duiHuaXuHao = 2;
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("背包客：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("昨天有人放火把麦田全烧了。");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("这些石头上还有残存的灰烬，上面一定有麦穗基因序列");
                                                duiHuaXuHao = 3;
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("你：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("是谁烧的？为什么要烧？");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("为什么要烧？");
                                                duiHuaXuHao = 4;
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("背包客：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("是……我不知道，");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("反正有人销毁证据！这些转基因麦子会导致土壤癌变…");
                                                duiHuaXuHao = 5;
                                            }
                                            break;
                                        }
                                    case 5:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                isTalk = false;
                                                for (int x = 0; x <= 80; x = x + 1)
                                                {
                                                    for (int y = 20; y <= 40; y = y + 1)
                                                    {
                                                        Console.SetCursorPosition(x, y);
                                                        Console.Write(" ");
                                                    }
                                                }
                                                for (int x = 50, y = 17; y < 40; y = y + 1) //道路下
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write("`");
                                                }
                                                for (int x = 2; x < 18; x = x + 2) //左石
                                                {
                                                    for (int y = 20; y < h - 10; y = y + 1)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                                        Console.SetCursorPosition(x, y);
                                                        Console.Write("石");
                                                    }
                                                }
                                                for (int x = 20; x < 40; x = x + 2) //下石
                                                {
                                                    for (int y = 30; y < h; y = y + 1)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                                        Console.SetCursorPosition(x, y);
                                                        Console.Write("石");
                                                    }
                                                }
                                                for (int x = 58; x < w - 2; x = x + 2) //右树
                                                {
                                                    for (int y = 15; y < h - 1; y = y + 1)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                        Console.SetCursorPosition(x, y);
                                                        Console.Write("木");
                                                    }
                                                }
                                                for (int i = h - 20; i >= h - 20 && i < h - 10; i = i + 1)//左侧下部
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(w - 80, i);
                                                    Console.Write("■");
                                                }
                                                for (int i = h - 30; i >= h - 30 && i < h; i = i + 1) //右侧
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(w - 2, i);
                                                    Console.Write("■");
                                                }
                                                for (int i = w - 60; i >= w - 60 && i < w - 40; i = i + 2) //底部左侧
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(i, h);
                                                    Console.Write("■");
                                                }
                                                for (int i = w - 20; i >= w - 20 && i < w; i = i + 2)//底部右侧
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(i, h);
                                                    Console.Write("■");
                                                }
                                                for (int x = w - 80, y = h - 10; x < w - 60 && y < h; x = x + 2, y = y + 1) //左侧
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write("■");
                                                }
                                                Console.ForegroundColor = NPCColor;
                                                Console.SetCursorPosition(30, 25);
                                                Console.Write(NPCIcon);
                                                if (((playerX == 28 || playerX == 32) && playerY == 25) || ((playerY == 24 || playerY == 26) && playerX == 30))//和左边人对话
                                                {
                                                    duiHuaXuHao = 1;
                                                }
                                                else
                                                {
                                                    duiHuaXuHao = 6;
                                                }
                                            }
                                            break;
                                        }
                                    case 6:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("你：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("报告上说，");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("死者家排水管通向你的捕捞区？");
                                                duiHuaXuHao = 7;
                                            }
                                            break;
                                        }
                                    case 7:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("钓鱼佬：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("他的污水毒死了三批鱼苗！看这变异鱼…");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("还有这药剂瓶碎片……");
                                                duiHuaXuHao = 8;
                                            }
                                            break;
                                        }
                                    case 8:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("你：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("这鱼完全不能吃了，这个药剂瓶……？");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("这药剂瓶上写着草铵膦");
                                                duiHuaXuHao = 9;
                                            }
                                            break;
                                        }
                                    case 9:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("钓鱼佬：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("肯定是药剂师干的！");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("这附近就他家在卖药！");
                                                duiHuaXuHao = 5;
                                            }
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (playerInput)
                                {
                                    case 'w':
                                    case 'W':
                                        playerY = playerY - 1;
                                        Console.SetCursorPosition(playerX, playerY + 1);
                                        Console.Write(" ");
                                        for (int x = 0, y = 17; x < 50; x = x + 2) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 50, y = 17; y < 40; y = y + 1) //道路下
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 50, y = 17; y > 6; x = 83 - 2 * y, y = y - 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if ((playerX == 30 && playerY == 25) || (playerX == 60 && playerY == 8))
                                        {
                                            playerY = playerY + 1;
                                        }
                                        break;
                                    case 'a':
                                    case 'A':
                                        playerX = playerX - 2;
                                        Console.SetCursorPosition(playerX + 2, playerY);
                                        Console.Write(" ");
                                        for (int x = 0, y = 17; x < 50; x = x + 2) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 50, y = 17; y < 40; y = y + 1) //道路下
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 50, y = 17; y > 6; x = 83 - 2 * y, y = y - 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if ((playerX == 30 && playerY == 25) || (playerX == 60 && playerY == 8))
                                        {
                                            playerX = playerX + 2;
                                        }
                                        break;
                                    case 's':
                                    case 'S':
                                        playerY = playerY + 1;
                                        Console.SetCursorPosition(playerX, playerY - 1);
                                        Console.Write(" ");
                                        for (int x = 0, y = 17; x < 50; x = x + 2) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 50, y = 17; y < 40; y = y + 1) //道路下
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 50, y = 17; y > 6; x = 83 - 2 * y, y = y - 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if ((playerX == 30 && playerY == 25) || (playerX == 60 && playerY == 8))
                                        {
                                            playerY = playerY - 1;
                                        }
                                        break;
                                    case 'd':
                                    case 'D':
                                        playerX = playerX + 2;
                                        Console.SetCursorPosition(playerX - 2, playerY);
                                        Console.Write(" ");
                                        for (int x = 0, y = 17; x < 50; x = x + 2) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 50, y = 17; y < 40; y = y + 1) //道路下
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 50, y = 17; y > 6; x = 83 - 2 * y, y = y - 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if ((playerX == 30 && playerY == 25) || (playerX == 60 && playerY == 8))
                                        {
                                            playerX = playerX - 2;
                                        }
                                        break;
                                    case 'l':
                                    case 'L':
                                        if (((playerX == 28 || playerX == 32) && playerY == 25) || ((playerY == 24 || playerY == 26) && playerX == 30))//和左边人对话
                                        {
                                            for (int x = 10, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 70, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 25, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 40, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 12; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            for (int x = 13; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("背包客：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("我还得多采集证据。");
                                                isTalk = true;//开启对话
                                                duiHuaXuHao = 1;
                                                isKiller2 = true;
                                            }
                                        }
                                        else if (((playerX == 58 || playerX == 62) && playerY == 8) || ((playerY == 7 || playerY == 9) && playerX == 60))//和右边人对话
                                        {
                                            for (int x = 10, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 70, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 25, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 40, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 12; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            for (int x = 13; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("钓鱼佬：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("我的鱼……我的鱼……");
                                                isTalk = true;//开启对话
                                                duiHuaXuHao = 6;
                                                isKiller3 = true;
                                            }
                                        }
                                        else if (tiShiDiTu2 == true && playerX == 76 && playerY == 39)
                                        {
                                            for (int x = 10, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 70, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 25, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 40, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 12; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            for (int x = 13; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("密码提示信息:（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("不止是一个字");
                                                isTalk = true;
                                                duiHuaXuHao = 5;
                                            }
                                        }
                                        break;
                                }
                            }
                            //上下阻挡玩家移动
                            if (playerY == h - 40)
                            {
                                playerY = playerY + 1;
                            }
                            else if (playerY == h && ((playerX >= w - 60 && playerX < w - 40) || (playerX >= w - 20 && playerX < w)))
                            {
                                playerY = playerY - 1;
                            }
                            else if (playerX >= 2 && playerX < 24 && playerY == 9)
                            {
                                playerY = playerY + 1;
                            }
                            else if (playerX >= 24 && playerX < 46 && playerY == 14)
                            {
                                playerY = playerY + 1;
                            }
                            else if (playerX >= 2 && playerX < 18 && playerY == 20)
                            {
                                playerY = playerY - 1;
                            }
                            else if (playerX >= 20 && playerX < 40 && playerY == 30)
                            {
                                playerY = playerY - 1;
                            }
                            else if (playerX >= 58 && playerX < 80 && playerY == 15)
                            {
                                playerY = playerY - 1;
                            }
                            else if (playerX >= 58 && playerX < 80 && playerY == 38)
                            {
                                playerY = playerY + 1;
                            }
                            else if (playerX >= 2 && playerX < 18 && playerY == 29)
                            {
                                playerY = playerY + 1;
                            }
                            //左右阻挡玩家移动
                            else if (playerX == w - 80 && ((playerY > h - 40 && playerY < h - 30) || (playerY >= h - 20 && playerY <= h - 10)))
                            {
                                playerX = playerX + 2;
                            }
                            else if (playerX == w - 2)
                            {
                                playerX = playerX - 2;
                            }
                            else if (playerY > 9 && playerY < 15 && playerX == 24)
                            {
                                playerX = playerX - 2;
                            }
                            else if (playerY > 15 && playerY < 39 && playerX == 58)
                            {
                                playerX = playerX - 2;
                            }
                            else if (playerY > 9 && playerY < 15 && playerX == 44)
                            {
                                playerX = playerX + 2;
                            }
                            else if (playerY > 20 && playerY < 30 && playerX == 16)
                            {
                                playerX = playerX + 2;
                            }
                            else if (playerY > 30 && playerY < 40 && playerX == 20)
                            {
                                playerX = playerX - 2;
                            }
                            else if (playerY > 30 && playerY < 40 && playerX == 38)
                            {
                                playerX = playerX + 2;
                            }
                            else if (playerY > 0 && playerY < 6 && playerX == 54)
                            {
                                playerX = playerX + 2;
                            }
                            //斜向阻挡玩家移动
                            else if ((playerX >= w - 80 && playerX < w - 60) && (playerY < h && playerY >= h - 10) && (playerX == 2 * playerY - 60))
                            {
                                playerX = playerX + 2;
                                playerY = playerY - 1;
                            }
                            else if (((playerX >= 44 && playerX < 54) && (playerY < 10 && playerY >= 5) && (playerX == 64 - 2 * playerY )))
                            {
                                playerX = playerX + 2;
                                playerY = playerY + 1;
                            }
                            else if (((playerX >= w - 20 && playerX < w) && (playerY < h - 30 && playerY >= h - 40) && (playerX == 2 * playerY + 60)))
                            {
                                playerX = playerX - 2;
                                playerY = playerY + 1;
                            }
                            //左侧切换区域
                            if (playerX == w - 80 && ((playerY >= h - 30 && playerY < h - 20) || (playerY < h && playerY > h - 10)))
                            {
                                nowSceneID = 1;
                                playerX = w - 4;
                                break;
                            }
                            //下侧切换区域
                            else if (playerY == h && ((playerX >= w - 40 && playerX <= w - 20) || (playerX > w - 80 && playerX < w - 60))) 
                            {
                                nowSceneID = 4;
                                playerY = h - 39;
                                break;
                            }
                            #endregion
                        }
                        break;
                    case 3://游戏场景三
                        Console.Clear();
                        #region 场景三边界
                        #region 横向
                        for (int i = w - 80; i < w - 60; i = i + 2)//顶部左侧
                        {
                            Console.SetCursorPosition(i, h - 40);
                            Console.Write("■");
                        }
                        for (int i = w - 40; i < w - 20; i = i + 2)//顶部右侧
                        {
                            Console.SetCursorPosition(i, h - 40);
                            Console.Write("■");
                        }
                        for (int i = w - 80; i < w; i = i + 2) //底部
                        {
                            Console.SetCursorPosition(i, h);
                            Console.Write("■");
                        }
                    #endregion
                        #region 纵向
                        for (int i = h - 40; i < h; i = i + 1)//左侧
                        {
                            Console.SetCursorPosition(w - 80, i);
                            Console.Write("■");
                        }
                        for (int i = h - 30; i < h - 20; i = i + 1) //右侧上部
                        {
                            Console.SetCursorPosition(w - 2, i);
                            Console.Write("■");
                        }
                        for (int i = h - 10; i >= h - 10 && i < h; i = i + 1) //右侧下部
                        {
                            Console.SetCursorPosition(w - 2, i);
                            Console.Write("■");
                        }
                    #endregion
                        #region 斜向
                        for (int x = w - 20, y = h - 40; x < w && y < h - 10; x = x + 2, y = y + 1)//右侧
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write("■");
                        }
                        #endregion
                        #endregion
                        #region 场景三装饰
                        for (int x = 30, y = 0; y < 25; y = y + 1) //道路左
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.SetCursorPosition(x, y);
                            Console.Write("`");
                        }
                        for (int x = 30, y = 10; x < 60; x = x + 2) //道路上
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.SetCursorPosition(x, y);
                            Console.Write("`");
                        }
                        for (int x = 30, y = 25; x < 80; x = x + 2) //道路下
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.SetCursorPosition(x, y);
                            Console.Write("`");
                        }
                        for (int x = 60, y = 10; y < 25; y = y + 1) //道路右
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.SetCursorPosition(x, y);
                            Console.Write("`");
                        }
                        for(int x = 2; x < 20; x = x + 2)//左树
                        {
                            for(int y = 1; y < 35; y = y + 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.SetCursorPosition(x, y);
                                Console.Write("木");
                            }
                        }
                        for(int x = 36; x < 74; x = x + 2)//下石
                        {
                            for(int y = 32; y < 40; y = y + 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.SetCursorPosition(x, y);
                                Console.Write("石");
                            }
                        }
                        if (tiShiDiTu3 == true) //地图三新增提示点
                        {
                            for (int x = 74, y = 39; ;)
                            {
                                Console.SetCursorPosition(x, y);
                                Console.Write("▲");
                                break;
                            }
                        }
                        #endregion
                        #region NPC设置
                        if (isKiller1 == true && isKiller2 == true && isKiller3 == true && isKiller4 == true)//全部对话结束出现凶手
                        //if (true)//临时使用
                        {
                            iskiller = true;
                            int x = 74, y = 3;
                            Console.SetCursorPosition(x, y);
                            Console.ForegroundColor = killerColor;
                            Console.Write("？");
                        }
                        #endregion
                        duiHuaXuHao = 1;
                        while (true)
                        {
                            #region #场景三玩家移动
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write(playerIcon);
                            playerInput = Console.ReadKey(true).KeyChar;
                            if(iskiller == true && isTalk == true)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                switch (duiHuaXuHao)
                                {
                                    case 1:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("你：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("你的收割刀呢？");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("死者的伤口显示是一种弯折的利器造成的。");
                                                duiHuaXuHao = 2;
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("凶手：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("都锁在仓库，");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("仓库密码只有死者知道，那密码用蛮力可打不开。");
                                                duiHuaXuHao = 3;
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("你：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("带我去仓库，");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("那是什么锁？");
                                                duiHuaXuHao = 4;
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("凶手：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("我带你去，");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("是密码锁，旁边有提示，你能解开吗？");
                                                duiHuaXuHao = 5;
                                            }
                                            break;
                                        }
                                    case 5:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("密码：(输入后按回车继续)");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("广字下加一个木念床，加两个木念麻，");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("加三个木念什么？");
                                                b = 36;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("输入密码(按回车后按L继续)：");
                                                passWord = Console.ReadLine();
                                                if (passWord == "麻木")
                                                {
                                                    a = 16;
                                                    b = 28;
                                                    Console.SetCursorPosition(a, b);
                                                    Console.Write("                                                 ");
                                                    Console.SetCursorPosition(a, b);
                                                    Console.Write("凶手：（按L继续对话）");
                                                    a = 20;
                                                    b = 32;
                                                    Console.SetCursorPosition(a, b);
                                                    Console.Write("                                                 ");
                                                    Console.SetCursorPosition(a, b);
                                                    Console.Write("可恶，让你找到了我的作案工具，");
                                                    b = 34;
                                                    Console.SetCursorPosition(a, b);
                                                    Console.Write("                                                 ");
                                                    Console.SetCursorPosition(a, b);
                                                    Console.Write("我先跑了。");
                                                    duiHuaXuHao = 6;
                                                }
                                                else
                                                {
                                                    tiShi = tiShi + 1;
                                                    a = 16;
                                                    b = 28;
                                                    Console.SetCursorPosition(a, b);
                                                    Console.Write("                                                 ");
                                                    Console.SetCursorPosition(a, b);
                                                    Console.Write("密码错误（按L继续）");
                                                    a = 20;
                                                    b = 32;
                                                    Console.SetCursorPosition(a, b);
                                                    Console.Write("                                                 ");
                                                    Console.SetCursorPosition(a, b);
                                                    Console.Write("密码错误");
                                                    b = 34;
                                                    Console.SetCursorPosition(a, b);
                                                    Console.Write("                                                 ");
                                                    Console.SetCursorPosition(a, b);
                                                    Console.Write("连续5次错误后");
                                                    b = 36;
                                                    Console.SetCursorPosition(a, b);
                                                    Console.Write("                                                 ");
                                                    Console.SetCursorPosition(a, b);
                                                    Console.Write("地图随机刷新提示信息。");
                                                    duiHuaXuHao = 6;
                                                }
                                            }
                                            break;
                                        }
                                    case 6:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                isTalk = false;
                                                for (int x = 0; x <= 80; x = x + 1)
                                                {
                                                    for (int y = 20; y <= 40; y = y + 1)
                                                    {
                                                        Console.SetCursorPosition(x, y);
                                                        Console.Write(" ");
                                                    }
                                                }
                                                for (int i = w - 80; i < w; i = i + 2) //底部
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(i, h);
                                                    Console.Write("■");
                                                }
                                                for (int i = h - 40; i < h; i = i + 1)//左侧
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(w - 80, i);
                                                    Console.Write("■");
                                                }
                                                for (int i = h - 10; i >= h - 10 && i < h; i = i + 1) //右侧下部
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(w - 2, i);
                                                    Console.Write("■");
                                                }
                                                for (int i = w - 80; i < w; i = i + 2) //底部
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(i, h);
                                                    Console.Write("■");
                                                }
                                                for (int x = 36; x < 74; x = x + 2)
                                                {
                                                    for (int y = 32; y < 40; y = y + 1)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                                        Console.SetCursorPosition(x, y);
                                                        Console.Write("石");
                                                    }
                                                }
                                                for (int x = 30, y = 0; y < 25; y = y + 1) //道路左
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write("`");
                                                }
                                                for (int x = 30, y = 25; x < 80; x = x + 2) //道路下
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write("`");
                                                }
                                                for (int x = 60, y = 10; y < 25; y = y + 1) //道路右
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write("`");
                                                }
                                                for (int x = 2; x < 20; x = x + 2)//左树
                                                {
                                                    for (int y = 1; y < 35; y = y + 1)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                        Console.SetCursorPosition(x, y);
                                                        Console.Write("木");
                                                    }
                                                }
                                                for (int x = 36; x < 74; x = x + 2)//下石
                                                {
                                                    for (int y = 32; y < 40; y = y + 1)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                                        Console.SetCursorPosition(x, y);
                                                        Console.Write("石");
                                                    }
                                                }
                                                duiHuaXuHao = 5;
                                                if (tiShi >= 5)
                                                {
                                                    break;
                                                }
                                            }
                                            if (tiShi >= 5)
                                            {
                                                break;
                                            }
                                            if (passWord == "麻木")
                                            {
                                                break;
                                            }
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                if (tiShi >= 5)//提示信息大于5次
                                {
                                    if (tiShiDiTu == 1)//随机到第一张图新增提示点
                                    {
                                        tiShiDiTu1 = true;
                                    }
                                    else if (tiShiDiTu == 2)//随机到第二张图新增提示点
                                    {
                                        tiShiDiTu2 = true;
                                    }
                                    else if (tiShiDiTu == 3) //随机到第三张图新增提示点
                                    {
                                        tiShiDiTu3 = true;
                                    }
                                    else if (tiShiDiTu == 4) //随机到第四张图新增提示点
                                    {
                                        tiShiDiTu4 = true;
                                    }
                                }
                                if (passWord == "麻木")
                                {

                                    nowSceneID = 5;//跳到战斗模式
                                    break;
                                }
                                switch (playerInput)
                                {
                                    case 'w':
                                    case 'W':
                                        playerY = playerY - 1;
                                        Console.SetCursorPosition(playerX, playerY + 1);
                                        Console.Write(" ");
                                        for (int x = 30, y = 0; y < 25; y = y + 1) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 30, y = 10; x < 60; x = x + 2) //道路上
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 30, y = 25; x < 80; x = x + 2) //道路下
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 60, y = 10; y < 25; y = y + 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if (iskiller == true && playerX == 74 && playerY == 3)
                                        {
                                            playerY = playerY + 1;
                                        }
                                        break;
                                    case 'a':
                                    case 'A':
                                        playerX = playerX - 2;
                                        Console.SetCursorPosition(playerX + 2, playerY);
                                        Console.Write(" ");
                                        for (int x = 30, y = 0; y < 25; y = y + 1) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 30, y = 10; x < 60; x = x + 2) //道路上
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 30, y = 25; x < 80; x = x + 2) //道路下
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 60, y = 10; y < 25; y = y + 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if (iskiller == true && playerX == 74 && playerY == 3)
                                        {
                                            playerX = playerX + 2;
                                        }
                                        break;
                                    case 's':
                                    case 'S':
                                        playerY = playerY + 1;
                                        Console.SetCursorPosition(playerX, playerY - 1);
                                        Console.Write(" ");
                                        for (int x = 30, y = 0; y < 25; y = y + 1) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 30, y = 10; x < 60; x = x + 2) //道路上
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 30, y = 25; x < 80; x = x + 2) //道路下
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 60, y = 10; y < 25; y = y + 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if (iskiller == true && playerX == 74 && playerY == 3)
                                        {
                                            playerY = playerY - 1;
                                        }
                                        break;
                                    case 'd':
                                    case 'D':
                                        playerX = playerX + 2;
                                        Console.SetCursorPosition(playerX - 2, playerY);
                                        Console.Write(" ");
                                        for (int x = 30, y = 0; y < 25; y = y + 1) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 30, y = 10; x < 60; x = x + 2) //道路上
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 30, y = 25; x < 80; x = x + 2) //道路下
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 60, y = 10; y < 25; y = y + 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if (iskiller == true && playerX == 74 && playerY == 3)
                                        {
                                            playerX = playerX - 2;
                                        }
                                        break;
                                    case 'l':
                                    case 'L':
                                        if (iskiller == true && (((playerX == 72 || playerX == 76) && playerY == 3) || ((playerY == 2 || playerY == 4) && playerX == 74)))
                                        {
                                            for (int x = 10, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 70, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 25, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 40, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 12; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            for (int x = 13; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            if(duiHuaXuHao == 1)
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("凶手：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("我一定能做出来最优质的麦子。");
                                                isTalk = true;//开启对话
                                                iskiller = true;
                                            }
                                            else
                                            {
                                                isTalk = true;
                                                iskiller = true;
                                            }
                                        }
                                        else if (tiShiDiTu == 3 && playerX == 74 && playerY == 39)
                                        {
                                            for (int x = 10, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 70, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 25, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 40, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 12; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            for (int x = 13; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            int a = 16, b = 28;
                                            Console.SetCursorPosition(a, b);
                                            Console.Write("密码提示信息:（按L继续对话）");
                                            a = 20;
                                            b = 32;
                                            Console.SetCursorPosition(a, b);
                                            Console.Write("不止是一个字");
                                            isTalk = true;
                                            duiHuaXuHao = 6;
                                        }
                                        break;
                                }
                            }
                            //上下阻挡玩家移动
                            if (playerY == h - 40 && ((playerX > w - 80 && playerX < w - 60) || (playerX >= w - 40) && (playerX < w - 20)))
                            {
                                playerY = playerY + 1;
                            }
                            else if (playerY == h)
                            {
                                playerY = playerY - 1;
                            }
                            else if (playerX >=2 && playerX < 20 && playerY == 34)
                            {
                                playerY = playerY + 1;
                            }
                            else if (playerX > 34 && playerX < 74 && playerY == 32)
                            {
                                playerY = playerY - 1;
                            }
                            //左右阻挡玩家移动
                            else if (playerX == w - 80)
                            {
                                playerX = playerX + 2;
                            }
                            else if (playerX == w - 2 && ((playerY >= h - 30 && playerY < h - 20) || (playerY >= h - 10 && playerY < h))) 
                            {
                                playerX = playerX - 2;
                            }
                            else if (playerY > 0 && playerY < 35 && playerX == 18)
                            {
                                playerX = playerX + 2;
                            }
                            else if (playerY > 32 && playerY < 40 && playerX == 36)
                            {
                                playerX = playerX - 2;
                            }
                            else if (playerY > 32 && playerY < 40 && playerX == 72)
                            {
                                playerX = playerX + 2;
                            }
                            //斜向阻挡玩家移动
                            else if (((playerX >= w - 20 && playerX < w) && (playerY < h - 30 && playerY >= h - 40) && (playerX == 2 * playerY + 60)))
                            {
                                playerX = playerX - 2;
                                playerY = playerY + 1;
                            }
                            //上侧切换区域
                            if (playerY == h - 40 && ((playerX >= w - 60 && playerX < w - 40)||(playerX > w - 20 && playerX < w - 2)))
                            {
                                nowSceneID = 1;
                                playerY = h - 1;
                                break;
                            }
                            //右侧切换区域
                            else if (playerX == w - 2 && ((playerY >= h - 20 && playerY <= h - 10)||(playerY > h - 40 && playerY < h - 30)))
                            {
                                nowSceneID = 4;
                                playerX = w - 78;
                                break;
                            }
                            #endregion
                        }
                        break;
                    case 4://游戏场景四
                        Console.Clear();
                        #region 场景四边界
                        #region 横向
                        for (int i = w - 60; i >= w - 60 && i < w - 40; i = i + 2) //顶部左侧
                        {
                            Console.SetCursorPosition(i, h - 40);
                            Console.Write("■");
                        }
                        for (int i = w - 20; i >= w - 20 && i < w; i = i + 2)//顶部右侧
                        {
                            Console.SetCursorPosition(i, h - 40);
                            Console.Write("■");
                        }
                        for (int i = w - 80; i < w; i = i + 2) //底部
                        {
                            Console.SetCursorPosition(i, h);
                            Console.Write("■");
                        }
                    #endregion
                        #region 纵向
                        for (int i = h - 32; i < h - 20; i = i + 1) //左侧上部
                        {
                            Console.SetCursorPosition(w - 80, i);
                            Console.Write("■");
                        }
                        for (int i = h - 10; i >= h - 10 && i < h; i = i + 1) //左侧下部
                        {
                            Console.SetCursorPosition(w - 80, i);
                            Console.Write("■");
                        }
                        for (int i = h - 40; i < h; i = i + 1)//右侧
                        {
                            Console.SetCursorPosition(w - 2, i);
                            Console.Write("■");
                        }
                        #endregion
                        #region 斜向
                        for (int x = w - 80, y = h - 30; x <= w - 74 && y > h - 40; x = x + 2, y = y - 1)//左侧
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write("■");
                        }
                        for (int x = w - 68, y = h - 36; x >= w - 68 && x <= w - 60 && y > h - 40; x = x + 2, y = y - 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write("■");
                        }
                        #endregion
                        #endregion
                        #region 场景四装饰
                        for (int x = 50, y = 0; y < 25; y = y + 1) //道路右
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.SetCursorPosition(x, y);
                            Console.Write("`");
                        }
                        for (int x = 0, y = 25; x < 50; x = x + 2) //道路下
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.SetCursorPosition(x, y);
                            Console.Write("`");
                        }
                        for (int x = 20, y = 25; x < 60 && y > 10; x = x + 2, y = y - 1)//道路中间
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.SetCursorPosition(x, y);
                            Console.Write("`");
                        }
                        for (int x = 12, y = 6; x < 36 && y < 30; x = x + 2, y = y + 1) //道路左
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.SetCursorPosition(x, y);
                            Console.Write("`");
                        }
                        for(int x = 2; x < 78; x = x + 2)//下树
                        {
                            for(int y = 30; y < 40; y = y + 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.SetCursorPosition(x, y);
                                Console.Write("木");
                            }
                        }
                        for (int x = 60; x < 78; x = x + 2)
                        {
                            for (int y = 1; y < 20; y = y + 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.SetCursorPosition(x, y);
                                Console.Write("石");
                            }
                        }
                        if (tiShiDiTu4 == true) //地图四新增提示点
                        {
                            for (int x = 50, y = 25; ;)
                            {
                                Console.SetCursorPosition(x, y);
                                Console.Write("▲");
                                break;
                            }
                        }
                        #endregion
                        #region 场景四NPC设置
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(46, 22);
                        Console.Write(NPCIcon);
                        #endregion
                        duiHuaXuHao = 1;
                        while (true)
                        {
                            #region #场景四玩家移动
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write(playerIcon);
                            playerInput = Console.ReadKey(true).KeyChar;
                            if (isTalk)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                switch (duiHuaXuHao)
                                {
                                    case 1:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("尸体：（按L继续）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("死者书桌抽屉发现未贴标的紫色除草剂");
                                                duiHuaXuHao = 2;
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("尸体：（按L继续）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("书房暗格内的账本记录killer虚报产量盗取补贴");
                                                duiHuaXuHao = 3;
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("尸体：（按L继续）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("死者随身衣物里有一支打火机，上面有转基因麦穗DNA");
                                                duiHuaXuHao = 4;
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                int a = 16, b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("尸体：（按L继续）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("死者房间下水道被改动过，通往鱼塘");
                                                duiHuaXuHao = 5;
                                            }
                                            break;
                                        }
                                    case 5:
                                        {
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                isTalk = false;
                                                for (int x = 0; x <= 80; x = x + 1)
                                                {
                                                    for (int y = 20; y <= 40; y = y + 1)
                                                    {
                                                        Console.SetCursorPosition(x, y);
                                                        Console.Write(" ");
                                                    }
                                                }
                                                for (int x = 2; x < 78; x = x + 2)//下树
                                                {
                                                    for (int y = 30; y < 40; y = y + 1)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                        Console.SetCursorPosition(x, y);
                                                        Console.Write("木");
                                                    }
                                                }
                                                for (int i = h - 10; i >= h - 10 && i < h; i = i + 1) //左侧下部
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(w - 80, i);
                                                    Console.Write("■");
                                                }
                                                for (int i = h - 40; i < h; i = i + 1)//右侧
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(w - 2, i);
                                                    Console.Write("■");
                                                }
                                                for (int i = w - 80; i < w; i = i + 2) //底部
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(i, h);
                                                    Console.Write("■");
                                                }
                                                for (int x = 50, y = 0; y < 25; y = y + 1) //道路右
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write("`");
                                                }
                                                for (int x = 0, y = 25; x < 50; x = x + 2) //道路下
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write("`");
                                                }
                                                for (int x = 20, y = 25; x < 60 && y > 10; x = x + 2, y = y - 1)//道路中间
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write("`");
                                                }
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.SetCursorPosition(46, 22);
                                                Console.Write(NPCIcon);
                                                duiHuaXuHao = 1;
                                            }
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (playerInput)
                                {
                                    case 'w':
                                    case 'W':
                                        playerY = playerY - 1;
                                        Console.SetCursorPosition(playerX, playerY + 1);
                                        Console.Write(" ");
                                        for (int x = 50, y = 0; y < 25; y = y + 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 0, y = 25; x < 50; x = x + 2) //道路下
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 20, y = 25; x < 60 && y > 10; x = x + 2, y = y - 1)//道路中间
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 12, y = 6; x < 36 && y < 30; x = x + 2, y = y + 1) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if (playerX == 46 && playerY == 22)
                                        {
                                            playerY = playerY + 1;
                                        }
                                        break;
                                    case 'a':
                                    case 'A':
                                        playerX = playerX - 2;
                                        Console.SetCursorPosition(playerX + 2, playerY);
                                        Console.Write(" ");
                                        for (int x = 50, y = 0; y < 25; y = y + 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 0, y = 25; x < 50; x = x + 2) //道路下
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 20, y = 25; x < 60 && y > 10; x = x + 2, y = y - 1)//道路中间
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 12, y = 6; x < 36 && y < 30; x = x + 2, y = y + 1) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if (playerX == 46 && playerY == 22)
                                        {
                                            playerX = playerX + 2;
                                        }
                                        break;
                                    case 's':
                                    case 'S':
                                        playerY = playerY + 1;
                                        Console.SetCursorPosition(playerX, playerY - 1);
                                        Console.Write(" ");
                                        for (int x = 50, y = 0; y < 25; y = y + 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 0, y = 25; x < 50; x = x + 2) //道路下
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 20, y = 25; x < 60 && y > 10; x = x + 2, y = y - 1)//道路中间
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 12, y = 6; x < 36 && y < 30; x = x + 2, y = y + 1) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if (playerX == 46 && playerY == 22)
                                        {
                                            playerY = playerY - 1;
                                        }
                                        break;
                                    case 'd':
                                    case 'D':
                                        playerX = playerX + 2;
                                        Console.SetCursorPosition(playerX - 2, playerY);
                                        Console.Write(" ");
                                        for (int x = 50, y = 0; y < 25; y = y + 1) //道路右
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 0, y = 25; x < 50; x = x + 2) //道路下
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 20, y = 25; x < 60 && y > 10; x = x + 2, y = y - 1)//道路中间
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        for (int x = 12, y = 6; x < 36 && y < 30; x = x + 2, y = y + 1) //道路左
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.SetCursorPosition(x, y);
                                            Console.Write("`");
                                        }
                                        if (playerX == 46 && playerY == 22)
                                        {
                                            playerX = playerX - 2;
                                        }
                                        break;
                                    case 'l':
                                    case 'L':
                                        if (((playerX == 44 || playerX == 48) && playerY == 22) || ((playerY == 21 || playerY == 23) && playerX == 46))
                                        {
                                            for (int x = 10, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 70, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 25, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 40, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 12; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            for (int x = 13; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            int a = 16, b = 28;
                                            Console.SetCursorPosition(a, b);
                                            Console.Write("尸体：（按L继续）");
                                            isTalk = true;//开启对话
                                            isKiller4 = true;
                                        }
                                        else if (tiShiDiTu == 4 && playerX == 50 && playerY == 25)
                                        {
                                            for (int x = 10, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 70, y = 25; y <= 40; y = y + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 25, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int y = 40, x = 10; x <= 70; x = x + 2)
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(x, y);
                                                Console.Write("口");
                                            }
                                            for (int x = 12; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            for (int x = 13; x < 70; x = x + 2)
                                            {
                                                for (int y = 26; y < 40; y = y + 1)
                                                {
                                                    Console.SetCursorPosition(x, y);
                                                    Console.Write(" ");
                                                }
                                            }
                                            int a = 16, b = 28;
                                            Console.SetCursorPosition(a, b);
                                            Console.Write("密码提示信息:（按L继续对话）");
                                            a = 20;
                                            b = 32;
                                            Console.SetCursorPosition(a, b);
                                            Console.Write("不止是一个字");
                                            isTalk = true;
                                            duiHuaXuHao = 5;
                                        }
                                        break;
                                }
                            }
                            //上下阻挡玩家移动
                            if (playerY == h - 40 && ((playerX >= w - 60 && playerX < w - 40) || (playerX >= w - 20 && playerX < w - 2)))
                            {
                                playerY = playerY + 1;
                            }
                            else if (playerY == h)
                            {
                                playerY = playerY - 1;
                            }
                            else if (playerY == 30)
                            {
                                playerY = playerY - 1;
                            }
                            else if (playerX > 58 && playerX < 80 && playerY == 19)
                            {
                                playerY = playerY + 1;
                            }
                            //左右阻挡玩家移动
                            else if (playerX == w - 80 && ((playerY >= h - 32 && playerY < h - 20) || (playerY >= h - 10 && playerY < h)))
                            {
                                playerX = playerX + 2;
                            }
                            else if (playerX == w - 2)
                            {
                                playerX = playerX - 2;
                            }
                            else if (playerY >0 && playerY < 20 && playerX == 60)
                            {
                                playerX = playerX - 2;
                            }
                            //斜向阻挡玩家移动
                            else if ((((playerX > w - 80 && playerX < w - 72) && (playerY > h - 34 && playerY < h - 30)) || ((playerX >= w - 68 && playerX < w - 60) && (playerY > h - 40 && playerY < h - 35))) && (playerX == 20 - 2 * playerY))
                            {
                                playerX = playerX + 2;
                                playerY = playerY + 1;
                            }
                            //上侧切换区域
                            if (playerY == h - 40 && ((playerX >= w - 40 && playerX < w - 20)||(playerX > w - 80 && playerX < w - 60)))
                            {
                                nowSceneID = 2;
                                playerY = h - 1;
                                break;
                            }
                            //左侧切换区域
                            else if (playerX == w - 80 && ((playerY >= h - 20 && playerY <= h - 10)||(playerY > h - 40 && playerY < h - 30)))
                            {
                                nowSceneID = 3;
                                playerX = w - 4;
                                break;
                            }
                            #endregion
                        }
                        break;
                    case 5://战斗场景
                        {
                            Console.Clear();
                            if(nowSceneID == 6)
                            {
                                break;
                            }
                            bool changJingWuDuiHua = false;
                            bool battle = false;
                            playerX = 40;
                            playerY = 30;
                            while (true)
                            {
                                bool end = false;
                                if (nowSceneID == 6 && end)
                                {
                                    break;
                                }
                                #region 场景五范围
                                for (int x = 0,y = 0; x < 80; x = x + 2)//上侧
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(x, y);
                                    Console.Write("■");
                                }
                                for(int x = 0, y = 40; x < 80; x = x + 2)//下侧
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(x, y);
                                    Console.Write("■");
                                }
                                for (int y = 0, x = 0; y < 40; y = y + 1)//左侧
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(x, y);
                                    Console.Write("■");
                                }
                                for (int y = 0, x = 78; y < 40; y = y + 1)//右侧
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(x, y);
                                    Console.Write("■");
                                }
                                for (int x = 0, y = 33; x < 80; x = x + 2)//中间
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(x, y);
                                    Console.Write("■");
                                }
                                #endregion

                                #region 场景五进入对话
                                if (changJingWuDuiHua == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(killerX, killerY);
                                    Console.Write("杀");
                                    for (int x = 10, y = 25; y <= 40; y = y + 1)
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.SetCursorPosition(x, y);
                                        Console.Write("口");
                                    }
                                    for (int x = 70, y = 25; y <= 40; y = y + 1)
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.SetCursorPosition(x, y);
                                        Console.Write("口");
                                    }
                                    for (int y = 25, x = 10; x <= 70; x = x + 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.SetCursorPosition(x, y);
                                        Console.Write("口");
                                    }
                                    for (int y = 40, x = 10; x <= 70; x = x + 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.SetCursorPosition(x, y);
                                        Console.Write("口");
                                    }
                                    for (int x = 12; x < 70; x = x + 2)
                                    {
                                        for (int y = 26; y < 40; y = y + 1)
                                        {
                                            Console.SetCursorPosition(x, y);
                                            Console.Write(" ");
                                        }
                                    }
                                    for (int x = 13; x < 70; x = x + 2)
                                    {
                                        for (int y = 26; y < 40; y = y + 1)
                                        {
                                            Console.SetCursorPosition(x, y);
                                            Console.Write(" ");
                                        }
                                    }
                                    int a = 16, b = 28;
                                    Console.SetCursorPosition(a, b);
                                    Console.Write("                                                 ");
                                    Console.SetCursorPosition(a, b);
                                    Console.Write("你：（按L继续对话）");
                                    a = 20;
                                    b = 32;
                                    Console.SetCursorPosition(a, b);
                                    Console.Write("                                                 ");
                                    Console.SetCursorPosition(a, b);
                                    Console.Write("终于追上了！");
                                    b = 34;
                                    Console.SetCursorPosition(a, b);
                                    Console.Write("                                                 ");
                                    Console.SetCursorPosition(a, b);
                                    Console.Write("我一定要让你伏法！");
                                    while (l == false)
                                    {
                                        playerInput = Console.ReadKey(true).KeyChar;
                                        if (playerInput == 'l' || playerInput == 'L')
                                        {
                                            try
                                            {
                                                a = 16;
                                                b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("系统：（按L继续对话）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("你有20点属性可以自由分配。");
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("最低攻击力8点，最高攻击力12点，血量100点");
                                                playerInput = Console.ReadKey(true).KeyChar;
                                                if (playerInput == 'l' || playerInput == 'L')
                                                {
                                                    duiHuaXuHao = 1;
                                                    while(shuxingfenpei == false)
                                                    {
                                                        switch (duiHuaXuHao)
                                                        {
                                                            case 1:
                                                                a = 16;
                                                                b = 28;
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("                                                 ");
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("系统：（按回车继续）");
                                                                a = 20;
                                                                b = 32;
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("                                                 ");
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("最低攻击力：8");
                                                                b = 34;
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("                                                 ");
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("分配点数：");
                                                                attackMin = int.Parse(Console.ReadLine());
                                                                duiHuaXuHao = 2;
                                                                break;
                                                            case 2:
                                                                a = 16;
                                                                b = 28;
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("                                                 ");
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("系统：（按回车继续）");
                                                                a = 20;
                                                                b = 32;
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("                                                 ");
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("最高攻击力：12");
                                                                b = 34;
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("                                                 ");
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("分配点数：");
                                                                attackMax = int.Parse(Console.ReadLine());
                                                                duiHuaXuHao = 3;
                                                                break;
                                                            case 3:
                                                                a = 16;
                                                                b = 28;
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("                                                 ");
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("系统：（按回车继续）");
                                                                a = 20;
                                                                b = 32;
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("                                                 ");
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("最大生命值：100");
                                                                b = 34;
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("                                                 ");
                                                                Console.SetCursorPosition(a, b);
                                                                Console.Write("分配点数：");
                                                                HP = int.Parse(Console.ReadLine());
                                                                duiHuaXuHao = 4;
                                                                sumAtkMin = playerAtkMin + attackMin;
                                                                sumAtkMax = playerAtkMax + attackMax;
                                                                sumHp = playerHp + HP;
                                                                break;
                                                            case 4:
                                                                if (HP + attackMin + attackMax == 20 && sumAtkMin < sumAtkMax && sumAtkMin > 0 && sumAtkMax > 0 && sumHp > 0)
                                                                {
                                                                    a = 16;
                                                                    b = 28;
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("                                                 ");
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("系统：（按回车继续）");
                                                                    a = 20;
                                                                    b = 32;
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("                                                 ");
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("最低攻击力为：" + sumAtkMin);
                                                                    b = 34;
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("                                                 ");
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("最大攻击力为：" + sumAtkMax);
                                                                    b = 36;
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("                                                 ");
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("生命值为：" + sumHp);
                                                                    shuxingfenpei = true;
                                                                    playerInput = Console.ReadKey(true).KeyChar;
                                                                }
                                                                else
                                                                {
                                                                    a = 16;
                                                                    b = 28;
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("                                                 ");
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("系统：（按回车继续）");
                                                                    a = 20;
                                                                    b = 32;
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("                                                 ");
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("属性为整数且不得小于1！");
                                                                    b = 34;
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("                                                 ");
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("或者你输入的数字不等于20！");
                                                                    b = 36;
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("                                                 ");
                                                                    Console.SetCursorPosition(a, b);
                                                                    Console.Write("或者最小攻击力大于最大攻击力！");
                                                                    playerInput = Console.ReadKey(true).KeyChar;
                                                                    duiHuaXuHao = 1;
                                                                }
                                                                break;
                                                        }
                                                    }
                                                }
                                            }
                                            catch
                                            {
                                                a = 16;
                                                b = 28;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("系统：（按L继续）");
                                                a = 20;
                                                b = 32;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("输入不正确！" );
                                                b = 34;
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("                                                 ");
                                                Console.SetCursorPosition(a, b);
                                                Console.Write("请输入数字！" );
                                            }
                                        }
                                        if(shuxingfenpei == true)
                                        {
                                            Console.Clear();
                                            changJingWuDuiHua = true;
                                            l = true;
                                            break;
                                        }
                                        if (l == false)
                                        {
                                            continue;
                                        }
                                    }
                                    #endregion
                                }
                                else if (battle == true)
                                {
                                    playerInput = Console.ReadKey(true).KeyChar;
                                    if (sumHp <= 0)
                                    {
                                        //游戏结束
                                        end = true;
                                        nowSceneID = 6;
                                        break;
                                    }
                                    else if (killerHp <= 0)
                                    {
                                        //killer擦除
                                        Console.SetCursorPosition(killerX, killerY);
                                        Console.Write("  ");
                                        battle = false;
                                    }
                                    else
                                    {
                                        Random r = new Random();
                                        int Atk = r.Next(sumAtkMin, sumAtkMax + 1);
                                        killerHp = killerHp - Atk;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.SetCursorPosition(2, 36);
                                        Console.WriteLine("                                             ");
                                        Console.SetCursorPosition(2, 36);
                                        Console.Write("你对凶手造成了{0}点伤害，凶手剩余血量{1}", Atk, killerHp);
                                        if (killerHp > 0)
                                        {
                                            Atk = r.Next(killerAtkMin, killerAtkMax + 1);
                                            sumHp = sumHp - Atk;
                                            Console.SetCursorPosition(2, 38);
                                            Console.WriteLine("                                             ");
                                            Console.SetCursorPosition(2, 38);
                                            Console.Write("凶手对你造成了{0}点伤害，你剩余血量{1}", Atk, sumHp);
                                            if (sumHp <= 0)
                                            {
                                                Console.SetCursorPosition(2, 36);
                                                Console.WriteLine("很遗憾，你未能打过凶手，成为了又一具尸体       ");
                                                playerInput = Console.ReadKey(true).KeyChar;
                                                if (playerInput == 'l' || playerInput == 'L')
                                                {
                                                    nowSceneID = 6;
                                                    gameOverInfo = "游戏结束";
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(2, 38);
                                                Console.Write("凶手对你造成了{0}点伤害，你剩余血量{1}", Atk, sumHp);
                                            }
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(2, 34);
                                            Console.WriteLine("                                         ");
                                            Console.SetCursorPosition(2, 36);
                                            Console.Write("你对凶手造成了{0}点伤害，凶手剩余血量{1}", Atk, killerHp);
                                            Console.SetCursorPosition(2, 34);
                                            Console.Write("你胜利了！让最终的凶手绳之以法！");
                                            playerInput = Console.ReadKey(true).KeyChar;
                                            if (playerInput == 'l' || playerInput == 'L')
                                            {
                                                nowSceneID = 6;
                                                gameOverInfo = "大神探！";
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    #region 绘制killer
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(killerX, killerY);
                                    Console.Write("杀");
                                    
                                    #endregion
                                    #region 场景五玩家移动
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(playerX, playerY);
                                    Console.Write(playerIcon);
                                    playerInput = Console.ReadKey(true).KeyChar;
                                    switch (playerInput)
                                    {
                                        case 'w':
                                        case 'W':
                                            playerY = playerY - 1;
                                            Console.SetCursorPosition(playerX, playerY + 1);
                                            Console.Write(" ");
                                            if(playerX == killerX && playerY == killerY)
                                            {
                                                playerY = playerY + 1;
                                            }
                                            break;
                                        case 'a':
                                        case 'A':
                                            playerX = playerX - 2;
                                            Console.SetCursorPosition(playerX + 2, playerY);
                                            Console.Write(" ");
                                            if (playerX == killerX && playerY == killerY)
                                            {
                                                playerX = playerX + 2;
                                            }
                                            break;
                                        case 's':
                                        case 'S':
                                            playerY = playerY + 1;
                                            Console.SetCursorPosition(playerX, playerY - 1);
                                            Console.Write(" ");
                                            if (playerX == killerX && playerY == killerY)
                                            {
                                                playerY = playerY - 1;
                                            }
                                            break;
                                        case 'd':
                                        case 'D':
                                            playerX = playerX + 2;
                                            Console.SetCursorPosition(playerX - 2, playerY);
                                            Console.Write(" ");
                                            if (playerX == killerX && playerY == killerY)
                                            {
                                                playerX = playerX - 2;
                                            }
                                            break;
                                        case 'l':
                                        case 'L':
                                            if (((playerX == 38 || playerX == 42) && playerY == 10)|| ((playerY == 11 || playerY == 9) && playerX == 40))
                                            {
                                                battle = true;
                                                Console.SetCursorPosition(2, 34);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine("开始凶手战斗了，按L键继续");
                                                Console.SetCursorPosition(2, 36);
                                                Console.WriteLine("你当前的血量是{0}", sumHp);
                                                Console.SetCursorPosition(2, 38);
                                                Console.WriteLine("凶手的血量是{0}", killerHp);
                                            }
                                            break;
                                    }
                                    #endregion
                                }
                                #region 阻止玩家移动
                                if(playerX == 0)
                                {
                                    playerX = playerX + 2;
                                }
                                if (playerX == 78)
                                {
                                    playerX = playerX - 2;
                                }
                                if (playerY == 0)
                                {
                                    playerY = playerY + 1;
                                }
                                if (playerY == 33)
                                {
                                    playerY = playerY - 1;
                                }
                                #endregion
                            }
                        }
                        break;
                    case 6:
                        Console.Clear();
                        Console.SetCursorPosition(36, 8);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("GameOver");
                        Console.SetCursorPosition(36, 10);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(gameOverInfo);
                        startSel = 0;
                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(36, 30);
                            Console.Write("结束游戏");
                            char input = Console.ReadKey(true).KeyChar;//判断当前选项
                            if (input == 'l' || input == 'L') 
                            {
                                Environment.Exit(0);
                            }
                        }
                }
            }
        }
    }
}
 
