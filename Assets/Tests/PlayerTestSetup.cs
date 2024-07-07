using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTests
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

    // Test to check if the Player's initial speed is set correctly
    [Test]
    public void Player_InitialSpeed_SetCorrectly()
    {
        player.Start();
        Assert.AreEqual(15f, Player.playerSpeed);
    }

    // Test to check if the Player's run speed is set correctly
    [Test]
    public void Player_RunSpeed_SetCorrectly()
    {
        player.Start();
        Assert.AreEqual(15f, player.runSpeed);
    }

    // Test to check if the Player's jump method sets the correct vertical direction
    [Test]
    public void Player_Jump_SetsVerticalDirection()
    {

        Vector3 vector3 = new Vector3();
        vector3 = player.transform.localPosition;
        player.Jump();
        Assert.AreEqual(10f, vector3.y);
    }

    // Test to check if the Player's slide method sets the correct collider properties
    [UnityTest]
    public IEnumerator Player_Slide_SetsColliderProperties()
    {
        player.Start(); // Initialize the Player

        player.Slide(); // Trigger the slide coroutine

        // Wait for a short duration to allow the slide coroutine to complete
        yield return new WaitForSeconds(1f);

        // Check if the collider properties are set back to normal after sliding
        Assert.AreEqual(new Vector3(0, 0, 0), player.colliderBox.center);
        Assert.AreEqual(2f, player.colliderBox.height);
    }

}
