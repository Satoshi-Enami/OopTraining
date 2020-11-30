using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{//インターフェース作成編 16
    public interface IShape 
    {
         double CalcArea();
    }

    //ポリモーフィズム特訓編
    class CalcSuper
    {
        public void CalcAreaAll(IEnumerable<IShape> shapes)
        {
            System.Diagnostics.Debug.WriteLine("面積の合計{0}", shapes.Sum(m => m.CalcArea()));
           
        }
    }
}
