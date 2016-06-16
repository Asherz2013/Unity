using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;

    [Test]
    public void T00_PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01_FirstStrike_ReturnsEndTurn()
    {
        ActionMaster actionMaster = new ActionMaster();
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }
}
