using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_2;
using System;
using System.Collections.Generic;

public class Link : ILink 
{
    /* Waiting on fixing this */ 

    State linkAttack;
    State linkUp;
    State linkDown;
    State linkRight;
    State linkLeft;
    State linkGetDamage;
    State linkUseItem;

    int healthVal, xVal, yVal;

    public int x { get; set; }
    public int y { get; set; }

    public int health { get; set; }

     //getting and setting

    State state;

    public Link()
    {
        // write default health, link state, and x and y locations
        linkAttack = new LinkAttack();
        linkUp = new LinkUp();
        linkDown = new LinkDown();
        linkRight = new  LinkRight();
        linkLeft = new LinkLeft();
        linkGetDamage = new LinkGetDamage();
        linkUseItem = new LinkUseItem();

        this.health = 100;
        this.xVal = x;  
        this.yVal = y;

        state = linkDown;

        this.state = state;

    }
    public void LinkState() {
        this.state = state;
    }
    public void LinkAttack() 
    { state.LinkAttack(); }

    public void LinkUseItem()
    { state.LinkUseItem(); }

    public void LinkUp()
    { state.LinkUp(); }

    public void LinkDown()
    { state.LinkDown(); }

    public void LinkRight()
    { state.LinksRight(); }

    public void LinkLeft()
    { state.LinkLeft(); }

    public void LinkGetDamage()
    { 
        state.LinkGetDamage();
        this.health = health - 5;
    
    }
   
}
