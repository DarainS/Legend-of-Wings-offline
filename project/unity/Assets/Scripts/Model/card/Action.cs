using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.damage;

namespace Assets.Scripts.Model.card
{
    class Action
    {
        public ActionType type;
        public int order;
        public Card source;
        public Character character;
        private Func<Object,Object> func1;
        
        public Action()
        {

        }
        public Action(ActionType type,int order,Card source,Func<Object, Object> func)
        {
            this.type = type;
            this.order = order;
            this.source = source;
            this.func1 = func;
        }

        public delegate void Make(string s);

        public void make1(string s)
        {
            Console.WriteLine("hello 1");
        }
        public void make2(string s)
        {
            Console.WriteLine("hello 2");
        }
        public static void Main(string[] args)
        {
            Action action = new Action();
            Make m1;
            m1 = action.make1;
            m1 += action.make2;
            m1 -= action.make1;
            m1("da");
               
        }
    }
}
