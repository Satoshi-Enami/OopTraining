using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fileName = args[0];
            var lines = new List<string>();

            // Csvファイルの読み込み
            using (var sr = new StreamReader(fileName, Encoding.UTF8, false))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            // Csvのファイル一行ずつの情報を格納
            // Csvのヘッダーを除くデータ部分は100行あるので、parsedArgsには100個のParsedArgsが入る
            var parsedArgs = new List<ParsedArgs>();
            foreach (var arg in lines.Skip(1))
            {
                parsedArgs.Add(new ParsedArgs(arg));
            }
            int calcCount = 0;
            List<Triangle> triangles = new List<Triangle>();
            foreach(var parsedArg in parsedArgs )
            {
                calcCount++;
                //クラス作成編 1
                Triangle triangle = new Triangle (parsedArg.TriangleBottom, parsedArg.TriangleHeight);

                triangles.Add(triangle);
                //クラス作成編 2
                System.Diagnostics.Debug.WriteLine("{0}個目：{1}" ,calcCount,triangle.CalcArea());
            }
            
            foreach (var triangle in triangles)
            {
                calcCount++;
                //Linq特訓編 3
                if (triangle.CalcArea() > 1000)
                {
                    System.Diagnostics.Debug.WriteLine("面積1000以上の三角形が存在します。");
                    break;
                }
            }

            //Linq特訓編 4
            if(triangles.Where(m => m.CalcArea() > 1000).ToList().Count > 1)
            {
                System.Diagnostics.Debug.WriteLine("面積1000以上の三角形が存在します。");
            }
            //Linq特訓編 5
            System.Diagnostics.Debug.WriteLine("面積1000以上の最初の三角形の面積は：{0}", triangles.Where(m => m.CalcArea() > 1000).FirstOrDefault().CalcArea());

            //Linq特訓編 6
            var test = triangles.Select((m, i) => new { area = m.CalcArea(), index = i }).Where(t => t.area > 1000).Select(m => m.index).FirstOrDefault();
            System.Diagnostics.Debug.WriteLine("{0}番目" ,test);
            //Linq特訓編 7
            System.Diagnostics.Debug.WriteLine("面積1000以上の最初の三角形の数は：{0}", triangles.Where(m => m.CalcArea() > 1000).ToList().Count);
            //Linq特訓編 8
            System.Diagnostics.Debug.WriteLine("面積1000以上の最初の三角形の面積の平均は：{0}", triangles.Where(m => m.CalcArea() > 1000).Average(m => m.CalcArea()));
            //Linq特訓編 9
           var test2 =   triangles.Where(m => m.CalcArea() > 1000).OrderByDescending(m => m.CalcArea()).ToList();
            test2.ForEach(m => { System.Diagnostics.Debug.WriteLine("{0}", m.CalcArea()); });

            //疑似クラス作成編
            System.Diagnostics.Debug.WriteLine("---疑似クラス作成編");
            calcCount = 0;
            List<Square> squares = new List<Square>();
            foreach (var parsedArg in parsedArgs)
            {
                calcCount++;
                //疑似クラス作成編 10
                Square square = new Square(parsedArg.SquareBottom, parsedArg.SquareHeight);

                squares.Add(square);
                //疑似クラス作成編11
                System.Diagnostics.Debug.WriteLine("{0}個目：{1}", calcCount, square.CalcArea());
            }
            //疑似クラス作成編12
            if (squares.Where(m => m.CalcArea() > 1000).ToList().Count > 1)
            {
                System.Diagnostics.Debug.WriteLine("面積1000以上の四角形が存在します。");
            }

            calcCount = 0;
            List<Circle> circles = new List<Circle>();
            foreach (var parsedArg in parsedArgs)
            {
                calcCount++;
                //疑似クラス作成編 13
                Circle circle = new Circle(parsedArg.CircleRadius);

                circles.Add(circle);
                //疑似クラス作成編14
                System.Diagnostics.Debug.WriteLine("{0}個目：{1}", calcCount, circle.CalcArea());
            }
            //疑似クラス作成編15
            if (circles.Where(m => m.CalcArea() > 1000).ToList().Count > 1)
            {
                System.Diagnostics.Debug.WriteLine("面積1000以上の円が存在します。");
            }


            //ポリモーフィズム特訓編
            CalcSuper calcSuper = new CalcSuper();
            System.Diagnostics.Debug.WriteLine("ポリモーフィズム特訓編");
            calcSuper.CalcAreaAll(triangles);
            calcSuper.CalcAreaAll(squares);
            calcSuper.CalcAreaAll(circles);

        }
    }




    /// <summary>
    /// 一行の情報をカンマで分解して格納
    /// </summary>
    public class ParsedArgs
    {
        public ParsedArgs(string args)
        {
            var fragment = args.Split(',');
            this.TriangleBottom = fragment[0];
            this.TriangleHeight = fragment[1];
            this.SquareBottom = fragment[2];
            this.SquareHeight = fragment[3];
            this.CircleRadius = fragment[4];
        }

        /// <summary>
        /// 三角形の底辺
        /// </summary>
        public string TriangleBottom { get; set; }

        /// <summary>
        /// 三角形の高さ
        /// </summary>
        public string TriangleHeight { get; set; }

        /// <summary>
        /// 正方形の底辺
        /// </summary>
        public string SquareBottom { get; set; }

        /// <summary>
        /// 正方形の高さ
        /// </summary>
        public string SquareHeight { get; set; }

        /// <summary>
        /// 円の半径
        /// </summary>
        public string CircleRadius { get; set; }



    }
}
