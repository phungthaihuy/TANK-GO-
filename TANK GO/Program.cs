using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANK_GO
{
    class Result
    {
        //    /*
        //     * Complete the 'Solve' function below.
        //     *
        //     * The function is expected to return a STRING.
        //     * The function accepts following parameters:
        //     *  1. STRING D
        //     *  2. INTEGER W
        //     *  3. STRING_ARRAY MAP
        // 
        public static string PrintMove(List<string> shortedPaths, int shortedPathsCount){
            string printMove = "";
            for (int i = 0; i < shortedPathsCount; i++)
            {
                printMove += shortedPaths[i];
            }
            return printMove;
        }

        public class Pair<T1, T2>{
            public  T1 First{
                get;
                set;
            }
            public  T2 Second{
                get;
                set;
            }
            public Pair(T1 first, T2 second){
                First = first;
                Second = second;
            }
            public Pair() { }


            public void Add(T1 first, T2 second)
            {
                this.First = first;
                this.Second = second;
            }
            public void AddFirst( T1 first){
                this.First = first;
            }

            public void AddSecond(T2 second){
                this.Second = second;
            }
        }

        public static string Solve(string D, int W, List<string> MAP){
            List<string> shortedPathsStr = new List<string>();
            List<Pair<int, int>> shortedPathsPair = new List<Pair<int, int>>();
            Pair<int, int> preMove = new Pair<int, int>();

            Pair<int, int> gPos = GetGPosition(W, MAP);
            Pair<int, int> tPos = GetTPosition(W, MAP);

            string printMove;
            string[] str = { "F", "F", "F", "F", "L", "R" };

            int gPosX = GetGPosX(W, MAP);
            int gPosY = GetGPosY(W, MAP);
            int[] dx = { 0, 0, 1, -1, 0, 0 };
            int[] dy = { 1, -1, 0, 0, 0, 0 };

            
            foreach (string item in MAP){
                char[] terrain;
                terrain = item.ToCharArray();
            }

            shortedPathsPair.Add(tPos);
            Pair<int, int> fatherNode = shortedPathsPair.First();

            //do{
                switch (D){
                    case "EAST":
                        int x = shortedPathsPair[0].First + dx[0];
                        int y = fatherNode.Second + dy[0];
                        preMove.Add(tPos.First, tPos.Second);
                        shortedPathsStr.Add(str[0]);

                        while (MAP[x][y] != 'G')
                        {
                            int xDistance = Math.Abs(gPos.First - x); int yDistance = Math.Abs(gPos.Second - y);
                            int turnDir = Math.Min(xDistance, yDistance);

                        if (turnDir == xDistance) //move xDir
                        {
                            if (x > preMove.First)
                            {
                                int xNew = x + 1;
                                int moveFDistance = Math.Abs(xNew - gPos.First);
                                int TDistance = Math.Abs(x - gPos.First);
                                if (x != gPos.First && MAP[xNew][y] != '#' && xNew < MAP.Count && (moveFDistance < TDistance || x > preMove.First)) {
                                    preMove.Add(x, y);
                                    x++;
                                    shortedPathsStr.Add(str[0]);
                                }
                                if (x == gPos.First || MAP[xNew][y] == '#' || moveFDistance > TDistance) //sw Dir to yDir
                                {
                                    if (y >= gPos.Second && x > preMove.First) // turnR
                                    {
                                        int yNew = y - 1;
                                        if (MAP[x][yNew] == '#') //obstacle, turnL
                                        {
                                            int lastCheckY = y + 1;
                                            if (MAP[x][lastCheckY] == '.')
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[4]);
                                                y++;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                        }

                                        if (MAP[x][yNew] == '.')
                                        {
                                            preMove.Add(x, y);
                                            shortedPathsStr.Add(str[5]);
                                            y--;
                                            shortedPathsStr.Add(str[0]);
                                        }

                                    }
                                    if (y <= gPos.Second && x > preMove.First) //turnL
                                    {
                                        int yNew = y + 1;
                                        if (MAP[x][yNew] == '#') //obstacle, turnR
                                        {
                                            int lastCheckY = y - 1;
                                            if (MAP[x][lastCheckY] == '.')
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[5]);
                                                y--;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                        }

                                        if (MAP[x][yNew] == '.')
                                        {
                                            preMove.Add(x, y);
                                            shortedPathsStr.Add(str[4]);
                                            y++;
                                            shortedPathsStr.Add(str[0]);
                                        }
                                    }
                                }
                            }

                            if (x < preMove.First)
                            {
                                int xNew = x - 1;
                                int moveFDistance = Math.Abs(xNew - gPos.First);
                                int TDistance = Math.Abs(x - gPos.First);
                                if (x != gPos.First && MAP[xNew][y] != '#' && xNew >= 0 && (moveFDistance < TDistance || x < preMove.First))
                                {
                                    preMove.Add(x, y);
                                    x--;
                                    shortedPathsStr.Add(str[0]);
                                }
                                if (x == gPos.First || MAP[xNew][y] == '#' || moveFDistance > TDistance) //sw Dir to yDir
                                {
                                    if (y >= gPos.Second && x < preMove.First) //turnL ///////////////////////////////////////
                                    {
                                        int yNew = y - 1;
                                        if (MAP[x][yNew] == '#') //obstacle, turnR
                                        {
                                            int lastCheckY = y + 1;
                                            if (MAP[x][lastCheckY] == '.')
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[5]);
                                                y++;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                        }

                                        if (MAP[x][yNew] == '.') ///
                                        {
                                            preMove.Add(x, y);
                                            shortedPathsStr.Add(str[4]);
                                            y--;
                                            shortedPathsStr.Add(str[0]);
                                        }
                                    }
                                    if (y <= gPos.Second && x < preMove.First) //turnR
                                    {
                                        int yNew = y + 1;
                                        if (MAP[x][yNew] == '#') //obstacle, turnL //////////////////////
                                        {
                                            int lastCheckY = y - 1;
                                            if (MAP[x][lastCheckY] == '.')
                                            {
                                                if (x != preMove.First) shortedPathsStr.Add(str[4]);
                                                preMove.Add(x, y);
                                                y--;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                        }

                                        if (MAP[x][yNew] == '.')
                                        {
                                            preMove.Add(x, y);
                                            shortedPathsStr.Add(str[5]);
                                            y++;
                                            shortedPathsStr.Add(str[0]);
                                        }
                                    }
                                }
                            }

                            if (x == preMove.First && y > preMove.Second) //sw Dir to yDir
                            {
                                int yNew = y + 1;
                                int moveFDistance = Math.Abs(yNew - gPos.Second);
                                int TDistance = Math.Abs(y - gPos.Second);
                                if (y != gPos.Second && MAP[x][yNew] != '#' && yNew < W && moveFDistance < TDistance)
                                {
                                    preMove.Add(x, y);
                                    y++;
                                    shortedPathsStr.Add(str[0]);
                                }
                                if ((y == gPos.Second && MAP[x][y] != 'G') || MAP[x][yNew] == '#' || moveFDistance > TDistance) //sw Dir to xDir
                                {
                                    if (x > gPos.First) //turnL
                                    {
                                        int xNew = x - 1;
                                        if (MAP[xNew][y] == '#') //obstacle, turnR
                                        {
                                            int lastCheckX = x + 1;
                                            if (MAP[lastCheckX][y] == '.')
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[5]);
                                                x++;
                                                shortedPathsStr.Add(str[0]);
                                            }

                                        }

                                        if (MAP[xNew][y] != '#')
                                        {
                                            preMove.Add(x, y);
                                            shortedPathsStr.Add(str[4]);
                                            x--;
                                            shortedPathsStr.Add(str[0]);
                                        }
                                    }
                                    if (x < gPos.First) //turnR
                                    {
                                        int xNew = x + 1;
                                        if (MAP[xNew][y] == '#') //obstacle, turnL
                                        {
                                            int lastCheckX = x - 1;
                                            if (MAP[lastCheckX][y] == '.')
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[5]);
                                                x--;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                        }

                                        if (MAP[xNew][y] != '#') //obstacle, turnL
                                        {
                                            preMove.Add(x, y);
                                            shortedPathsStr.Add(str[5]);
                                            x++;
                                            shortedPathsStr.Add(str[0]);
                                        }
                                    }
                                }
                            }
                            if (x == preMove.First && y < preMove.Second)
                            {
                                int yNew = y - 1;
                                int moveFDistance = Math.Abs(yNew - gPos.Second);
                                int TDistance = Math.Abs(y - gPos.Second);
                                if (y != gPos.Second && MAP[x][yNew] != '#' && yNew >= 0 && (moveFDistance < TDistance || y < preMove.Second))
                                {
                                    preMove.Add(x, y);
                                    y--;
                                    shortedPathsStr.Add(str[0]);
                                }
                                if ((y == gPos.Second && MAP[x][y] != 'G') || MAP[x][yNew] == '#' || moveFDistance > TDistance) //sw Dir to xDir
                                {
                                    if (x > gPos.First) //turnR
                                    {
                                        int xNew = x - 1;
                                        if (MAP[xNew][y] == '#')//obstacle, turnL
                                        {
                                            int lastCheckX = x + 1;
                                            if (MAP[lastCheckX][y] == '.')
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[4]);
                                                x++;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                            
                                        }

                                        if (MAP[xNew][y] != '#')
                                        {
                                            preMove.Add(x, y);
                                            shortedPathsStr.Add(str[5]);
                                            x--;
                                            shortedPathsStr.Add(str[0]);
                                        }
                                    }
                                    if (x < gPos.First) //turnL
                                    {
                                        int xNew = x + 1;
                                        if (MAP[xNew][y] == '#')//obstacle, turnR
                                        {
                                            int lastCheckX = x - 1;
                                            if (MAP[lastCheckX][y] == '.')
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[5]);
                                                x--;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                        }

                                        if (MAP[xNew][y] != '#')
                                        {
                                            preMove.Add(x, y);
                                            shortedPathsStr.Add(str[4]);
                                            x++;
                                            shortedPathsStr.Add(str[0]);
                                        }
                                    }
                                }
                            }
                        }

                        else if (turnDir == yDistance) //move yDir
                        {
                            if (y > preMove.Second)
                            {
                                int yNew = y + 1;
                                int moveFDistance = Math.Abs(yNew - gPos.Second);
                                int TDistance = Math.Abs(y - gPos.Second);
                                if (y != gPos.Second && yNew < W && MAP[x][yNew] != '#' && (moveFDistance < TDistance || y > preMove.Second))
                                {
                                    preMove.Add(x, y);
                                    y++;
                                    shortedPathsStr.Add(str[0]);
                                }
                                if (y == gPos.Second || moveFDistance > TDistance || MAP[x][yNew] == '#') //sw Dir to xDir
                                {
                                    //preMove.Add(x, y);
                                    if (x >= gPos.First && y > preMove.Second) //turnL
                                    {
                                        int xNew = x - 1;
                                        if (MAP[xNew][y] == '#')//obstacle, turnR
                                        {
                                            int lastCheckX = x + 1;
                                            if (MAP[lastCheckX][y] == '.')
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[5]);
                                                x++;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                        }

                                        if (MAP[xNew][y] != '#')//obstacle, turnR
                                        {
                                            preMove.Add(x, y);
                                            shortedPathsStr.Add(str[4]);
                                            x--;
                                            shortedPathsStr.Add(str[0]);
                                        }
                                    }
                                    if (x <= gPos.First && y > preMove.Second) //turnR
                                    {
                                        int xNew = x - 1;
                                        if (MAP[xNew][y] == '#')//obstacle, turnL
                                        {
                                            int lastCheckX = x + 1;
                                            if (MAP[lastCheckX][y] == '.')
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[4]);
                                                x++;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                        }

                                        if (MAP[xNew][y] != '#')
                                        {
                                            preMove.Add(x, y);
                                            shortedPathsStr.Add(str[5]);
                                            x--;
                                            shortedPathsStr.Add(str[0]);
                                        }
                                    }
                                }
                            }

                            if (y < preMove.Second)
                            {
                                int yNew = y - 1;
                                int moveFDistance = Math.Abs(yNew - gPos.Second);
                                int TDistance = Math.Abs(y - gPos.Second);
                                if (y != gPos.Second && MAP[x][yNew] != '#' && yNew >= 0 && (moveFDistance < TDistance || y < preMove.Second))
                                {
                                    preMove.Add(x, y);
                                    y--;
                                    shortedPathsStr.Add(str[0]);
                                }
                                if (y == gPos.Second || MAP[x][yNew] == '#' || moveFDistance > TDistance) //sw Dir to xDir
                                {
                                    if (x >= gPos.First && y < preMove.Second) //turnR
                                    {
                                        int xNew = x - 1;
                                        if (MAP[xNew][y] == '#' )//obstacle, turnL
                                        {
                                            int lastCheckX = x + 1;
                                            if (MAP[lastCheckX][y] == '.')
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[4]);
                                                x++;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                            
                                        }

                                        if (MAP[xNew][y] != '#' && (x - 1) != gPos.First)//obstacle, turnL
                                        {
                                            preMove.Add(x, y);
                                            shortedPathsStr.Add(str[5]);
                                            x--;
                                            shortedPathsStr.Add(str[0]);
                                        }
                                    }
                                    if (x <= gPos.First && y < preMove.Second) //turnL
                                    {
                                        int xNew = x - 1;
                                        if (MAP[xNew][y] == '#' && (x + 1) != gPos.First)//obstacle, turnR
                                        {
                                            preMove.Add(x, y);
                                            shortedPathsStr.Add(str[5]);
                                            x++;
                                            shortedPathsStr.Add(str[0]);
                                        }

                                        if (MAP[xNew][y] != '#' && (x - 1) != gPos.First)//obstacle, turnR
                                        {
                                            int lastCheckX = x - 1;
                                            if (MAP[lastCheckX][y] == '.')
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[4]);
                                                x--;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                        }
                                    }
                                }
                            }

                            if (y == preMove.Second && x < preMove.First) //switch Dir to xDir
                            {
                                int xNew = x - 1;
                                int moveFDistance = Math.Abs(xNew - gPos.First);
                                int TDistance = Math.Abs(x - gPos.First);
                                if (x != gPos.First && MAP[xNew][y] != '#' && xNew >= 0 && moveFDistance < TDistance)
                                {
                                    preMove.Add(x, y);
                                    x--;
                                    shortedPathsStr.Add(str[0]);
                                }
                                if ((x == gPos.First && MAP[x][y] != 'G') || MAP[xNew][y] == '#' || moveFDistance > TDistance) //sw Dir to yDir
                                    { 
                                        int yNewR = y + 1;
                                        int yNewL = y - 1;
                                        if(y <= gPos.Second && yNewR < W ) //turnR
                                        {
                                            
                                            if (MAP[x][yNewR] == '#' && (y - 1) != preMove.Second)//obstacle, turnL
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[4]);
                                                y--;
                                                shortedPathsStr.Add(str[0]);
                                            }

                                            if (MAP[x][yNewR] != '#' && (y + 1) != preMove.Second)
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[5]);
                                                y++;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                        }
                                        if(y >= gPos.Second && yNewL < W) //turnL
                                        {
                                            if (MAP[x][yNewL] == '#' && (y + 1) != preMove.Second)//obstacle, turnR
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[5]);
                                                y++;
                                                shortedPathsStr.Add(str[0]);
                                            }

                                            if (MAP[x][yNewL] != '#' && (y - 1) != preMove.Second)
                                            {
                                                if(x != preMove.First) shortedPathsStr.Add(str[4]);
                                                preMove.Add(x, y);
                                                y--;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                        }
                                    }
                                }
                                if (y == preMove.Second && x > preMove.First)
                                {
                                    int xNew = x + 1;
                                    int moveFDistance = Math.Abs(xNew - gPos.First);
                                    int TDistance = Math.Abs(x - gPos.First);
                                    
                                    if (x != gPos.First && MAP[xNew][y] != '#' && xNew < MAP.Count && moveFDistance < TDistance)
                                    {
                                        preMove.Add(x, y);
                                        x++;
                                        shortedPathsStr.Add(str[0]);
                                    }
                                    if ((x == gPos.First && MAP[x][y] != 'G') || MAP[xNew][y] == '#' || moveFDistance > TDistance) //sw Dir to yDir
                                    {
                                        if (y < gPos.Second) //turnL
                                        {
                                            int yNew = y + 1;
                                            if (MAP[x][yNew] == '#' && (y - 1) != preMove.Second)//obstacle, turnR
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[5]);
                                                y--;
                                                shortedPathsStr.Add(str[0]);
                                            }

                                            if (MAP[x][yNew] != '#' && (y + 1) != preMove.Second)//obstacle, turnR
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[4]);
                                                y++;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                        }
                                        if (y > gPos.Second) //turnR
                                        {
                                            int yNew = y - 1;
                                            if (MAP[x][yNew] == '#' && (y + 1) != preMove.Second)//obstacle, turnL
                                            {
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[4]);
                                                y++;
                                                shortedPathsStr.Add(str[0]);
                                            }

                                            if (MAP[x][yNew] != '#' && (y - 1) != preMove.Second)
                                            {
                                                
                                                preMove.Add(x, y);
                                                shortedPathsStr.Add(str[5]);
                                                y--;
                                                shortedPathsStr.Add(str[0]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
            //} while (!shortedPathsPair.Contains(gPos));

                printMove = PrintMove(shortedPathsStr, shortedPathsStr.Count);
            return printMove;
        }

        public static Pair<int, int> GetGPosition(int W, List<string> MAP){
            int gPosX = 0, gPosY = 0;
            for (int i = 0; i < MAP.Count; i++){
                for (int j = 0; j < W; j++){
                    if (MAP[i][j] == 'G'){ //check position T
                        gPosX = i;
                        gPosY = j;
                        break;
                    }
                    else continue;
                }
            }
            Pair<int, int> gPos = new Pair<int, int>();
            gPos.First = gPosX; gPos.Second = gPosY;//get position G
            return gPos;
        }

        public static int GetGPosX(int W, List<string> MAP){
            int gPosX = 0, gPosY = 0;
            for (int i = 0; i < MAP.Count; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (MAP[i][j] == 'G')
                    { //check position T
                        gPosX = i;
                        gPosY = j;
                        break;
                    }
                    else continue;
                }
            }
            return gPosX;
        }

        public static int GetGPosY(int W, List<string> MAP)
        {
            int gPosX = 0, gPosY = 0;
            for (int i = 0; i < MAP.Count; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (MAP[i][j] == 'G')
                    { //check position T
                        gPosX = i;
                        gPosY = j;
                        break;
                    }
                    else continue;
                }
            }
            return gPosY;
        }

        public static Pair<int, int> GetTPosition(int W, List<string> MAP){
            int tPosX = 0, tPosY = 0;
            for (int i = 0; i < MAP.Count; i++) {
                for (int j = 0; j < W; j++){
                    if (MAP[i][j] == 'T'){//check position T {
                        tPosX = i;
                        tPosY = j;
                        break;
                    }
                    else continue;
                }
            }
            Pair<int, int> tPos = new Pair<int, int>();
            tPos.First = tPosX; tPos.Second = tPosY; //get position T
            return tPos;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string D = Console.ReadLine();

            int W = Convert.ToInt32(Console.ReadLine().Trim());

            int MAPCount = Convert.ToInt32(Console.ReadLine().Trim());



            List<string> MAP = new List<string>();

            for (int i = 0; i < MAPCount; i++){
                string MAPItem = Console.ReadLine();
                MAP.Add(MAPItem);
            }

            Console.WriteLine(Result.Solve(D, W, MAP));
        }
    }
}
