using System;
using Microsoft.Xna.Framework;
using sprint0;
using sprint0.LinkObj;


public class Camera
{
    // MAKE BOOLEAN TO CHECK WHEN SCROLLSTATE IS OVER!!!!
    private Vector2 cameraPosition;
    private Vector2 targetPosition; // Target position for smooth scrolling
    private int roomHeight, roomWidth;
    private float lerpFactor = 0.01f; // the higher the number, the faster it scrolls
    private GraphicsDeviceManager graphicsDeviceManager;
    public Matrix Transform { get; private set; }
    public float getCameraXPos() { return cameraPosition.X; }

    public float getCameraYPos() { return cameraPosition.Y; }

    public Camera() {
        // up to change later
        roomHeight = 160;
        roomWidth = 120;

        
    }
    /* The Camera now follows Link 
     * Haven't been able to get the logic behind the screen scrolling but working on it. But use this as a guide :)
     */
    public void FollowLink(GraphicsDeviceManager graphics, Boolean follow)
    {
        if (follow)
        {
            // Assuming link.xPosition() and link.yPosition() return the center position of Link
            cameraPosition = new Vector2(-Globals.Link.xPosition(), -Globals.Link.yPosition());
            graphicsDeviceManager = graphics;
            UpdateTransform(graphicsDeviceManager);
            targetPosition = cameraPosition;
        }
    }

    private void UpdateTransform(GraphicsDeviceManager graphics)
    {
        int width = graphics.PreferredBackBufferWidth / 2;
        int height = graphics.PreferredBackBufferHeight / 2;

        var position = Matrix.CreateTranslation(cameraPosition.X, cameraPosition.Y, 0);
        var offset = Matrix.CreateTranslation(width, height, 0);

        Transform = position * offset;
    }

    public void MoveCameraLeft(int units)
    {
        cameraPosition.X += units; // Adjust this value as needed
        UpdateTransform(graphicsDeviceManager);
        targetPosition = cameraPosition;
    }

    public void MoveCameraRight(int units)
    {
        cameraPosition.X -= units; // Adjust this value as needed
        UpdateTransform(graphicsDeviceManager);
        targetPosition = cameraPosition;
    }

    public void MoveCameraUp(int units)
    {
        cameraPosition.Y += units; // Adjust this value as needed
        UpdateTransform(graphicsDeviceManager);
        targetPosition = cameraPosition;
    }

    public void MoveCameraDown(int units)
    {
        cameraPosition.Y -= units; // Adjust this value as needed
        UpdateTransform(graphicsDeviceManager);
        targetPosition = cameraPosition;
    }

    // for smooth scrolling
    public void MoveCameraToLeftRoom()
    {
        targetPosition = new Vector2(cameraPosition.X + roomWidth ,cameraPosition.Y);
    }

    public void MoveCameraToRightRoom()
    {
        targetPosition = new Vector2(cameraPosition.X - roomWidth, cameraPosition.Y);
    }

    public void MoveCameraToTopRoom()
    {
        targetPosition = new Vector2(cameraPosition.X, cameraPosition.Y + roomHeight);
    }

    public void MoveCameraToBottomRoom()
    {
        targetPosition = new Vector2(cameraPosition.X, cameraPosition.Y - roomHeight);
    }

    // Update method for smooth scrolling
    public void Update(GameTime gameTime)
    {
        // Interpolate smoothly between the current position and the target position
        cameraPosition = Vector2.Lerp(cameraPosition, targetPosition, lerpFactor);

        // Update the transform with the new camera position
        UpdateTransform(graphicsDeviceManager);
    }
    public Boolean cameraMovementComplete() {

        // Calculate the distance between the current and target positions
        float distance = Vector2.Distance(cameraPosition, targetPosition);

        // If the distance is less than the threshold, consider scrolling as over
        return distance < 1.0f;
    }
}