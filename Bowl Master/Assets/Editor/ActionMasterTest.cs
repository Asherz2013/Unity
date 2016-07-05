//using UnityEngine;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEditor;
//using NUnit.Framework;

//[TestFixture]
//public class ActionMasterTest
//{
//    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
//    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
//    private ActionMaster.Action reset = ActionMaster.Action.Reset;
//    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    
//    private List<int> pinFalls;

//    [SetUp]
//    public void Setup()
//    {
//        pinFalls = new List<int>();
//    }

//    [Test]
//    public void T00_PassingTest()
//    {
//        Assert.AreEqual(1, 1);
//    }

//    [Test]
//    public void T01_FirstStrike_ReturnsEndTurn()
//    {
//        pinFalls.Add(10);
//        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
//    }

//    [Test]
//    public void T02_Bowl8ReturnsTidy()
//    {
//        pinFalls.Add(8);
//        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
//    }

//    [Test]
//    public void T03_Bowl_2_8_ReturnsEndTurn()
//    {
//        int[] rolls = {2, 8};
//        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T04_CheckRest_AtStrikeInLastFrame()
//    {
//        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10 };
//        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T05_CheckRest_AtSpareInLastFrame()
//    {
//        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9 };
//        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T06_YouTube_Rolls_EndInEndGame()
//    {
//        int[] rolls = { 8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2,9 };
//        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T07_GameEndsAtBowl20()
//    {
//        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,2 };
//        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T08_CheckTidy_DarylBowl20Test()
//    {
//        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,5 };
//        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T09_CheckTidy_BensBowl20Test()
//    {
//        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,0 };
//        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T10_Nathan_test()
//    {
//        int[] rolls = { 0,10, 5,1 };
//        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T11_Dondi10thFrameTurkey()
//    {
//        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,10,10 };
//        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
//    }
//}
