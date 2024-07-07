using NUnit.Framework;
using UnityEngine;

public class PlayerLaneTests
{
    // Reference to the Player object
    private Player player;

    // Setup method to instantiate the Player object before each test
    [SetUp]
    public void Setup()
    {
        GameObject playerGameObject = new GameObject();
        player = playerGameObject.AddComponent<Player>();
    }

    // Test to check if the desired lane is initially set to the middle lane (lane 1)
    [Test]
    public void Player_InitialDesiredLane_IsMiddleLane()
    {
        Assert.AreEqual(1, player.desiredLane);
    }

    // Test to check if swiping left updates the desired lane correctly
    [Test]
    public void Player_SwipeLeft_UpdatesDesiredLane()
    {
        player.Update();
        // Initially set desired lane to middle lane (lane 1)
        //player.desiredLane = 1;

        // Simulate swiping left
        SwipeManager.swipeLeft = true;

        // Call Update method to handle input
        //player.Update();

        // Check if the desired lane is updated to left lane (lane 0)
        Assert.AreEqual(0, player.desiredLane);
    }

    // Test to check if swiping right updates the desired lane correctly
    [Test]
    public void Player_SwipeRight_UpdatesDesiredLane()
    {
        // Initially set desired lane to middle lane (lane 1)
        //player.desiredLane = 1;

        // Simulate swiping right
        SwipeManager.swipeRight = true;

        // Call Update method to handle input
        player.Update();

        // Check if the desired lane is updated to right lane (lane 2)
        Assert.AreEqual(2, player.desiredLane);
    }
}
