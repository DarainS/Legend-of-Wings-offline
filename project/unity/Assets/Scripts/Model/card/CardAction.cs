using System;
using System.Collections.Generic;


using Model;
using Model.card;
using Model.damage;



    public class CardAction<T, R> : IComparer<CardAction<T, R>> {

        public ActionType type;

        public int order;

        public Card source;

        public Character character;

        private Func<T, R> func;


        public CardAction(int order, Func<T, R> func) {
            this.order = order;
            this.func = func;
        }

        public R playEffect(T t) {
            return func(t);
        }


        public delegate void Make(string s);


        public void make1(string s) {
            Console.WriteLine("hello 1");
        }

        public void make2(string s) {
            Console.WriteLine("hello 2");
        }

        public static void Main(string[] args) {
//            Action action = new Action();
//            Make m1;
//            m1 = action.make1;
//            m1 += action.make2;
//            m1 -= action.make1;
//            m1("da");
        }

        public int Compare(CardAction<T, R> x, CardAction<T, R> y) {
            if(x.order > y.order) {
                return 1;
            }
            if(x.order < y.order) {
                return -1;
            }

            return 0;
        }

    }

