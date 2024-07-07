using NUnit.Framework;
using UnityEngine;
public class SwipeManagerTests
{
    // Reference to the SwipeManager object
    private SwipeManager swipeManager;

    // Setup method to instantiate the SwipeManager object before each test
    [SetUp]
    public void Setup()
    {
        GameObject swipeManagerGameObject = new GameObject();
        swipeManager = swipeManagerGameObject.AddComponent<SwipeManager>();
    }

    // Test to check if tap is detected correctly
    [Test]
    public void SwipeManager_TapDetected_Correctly()
    {
        // Simulate mouse button down

        // Call Update method to handle input
        swipeManager.Update();

        // Check if tap flag is set to true
        Assert.IsTrue(SwipeManager.tap);
    }

    // Test to check if swipe left is detected correctly
    
}

