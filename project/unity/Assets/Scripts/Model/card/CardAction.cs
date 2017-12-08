using System;
using System.Collections.Generic;

using Model;
using Model.card;
using Model.damage;


public class CardAction<T, R> : IComparer<CardAction<T, R>> {

    public int Order;

    public Card source;

    public Character character;

    private readonly Func<T, R> func;


    public CardAction(int order, Func<T, R> func) {
        this.Order = order;
        this.func = func;
    }

    public R playEffect(T t) {
        return func(t);
    }


    public int Compare(CardAction<T, R> x, CardAction<T, R> y) {
        if(x.Order > y.Order) {
            return 1;
        }
        if(x.Order < y.Order) {
            return -1;
        }

        return 0;
    }

}