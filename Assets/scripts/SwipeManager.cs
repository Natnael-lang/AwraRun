using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    // Flags to indicate different swipe directions and tap
    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;

    // Variables for tracking swipe and drag
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    public void Update()
    {
        // Reset all flags at the beginning of each frame
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;

        #region Standalone Inputs
        // Check for mouse button down to detect tap and start drag
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        // Check for mouse button up to end drag
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Input
        // Check for touch input
        if (Input.touches.Length > 0)
        {
            // Check touch phase to detect tap and start drag
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            // Check touch phase to end drag
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        // Calculate the swipe distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            // Calculate swipe delta based on touch/mouse position
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        // Check if swipe distance exceeds a threshold
        if (swipeDelta.magnitude > 100)
        {
            // Determine swipe direction based on the larger component of swipeDelta
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Swipe is predominantly horizontal
                if (x < 0)
                    swipeLeft = true; // Set swipeLeft flag if swiping left
                else
                    swipeRight = true; // Set swipeRight flag if swiping right
            }
            else
            {
                // Swipe is predominantly vertical
                if (y < 0)
                    swipeDown = true; // Set swipeDown flag if swiping down
                else
                    swipeUp = true; // Set swipeUp flag if swiping up
            }

            Reset(); // Reset tracking variables after swipe detection
        }
    }

    // Reset tracking variables
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}