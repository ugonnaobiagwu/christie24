using System;
using Microsoft.Xna.Framework;
using sprint0;
using sprint0.LinkObj;


public class Camera
{
    private Vector2 cameraPosition;
    private GraphicsDeviceManager graphicsDeviceManager;
    public Matrix Transform { get; private set; }
    public float getCameraXPos() { return cameraPosition.X; }

    public float getCameraYPos() { return cameraPosition.Y; }

    /* The Camera now follows Link 
     * Haven't been able to get the logic behind the screen scrolling but working on it. But use this as a guide :)
     */
    public void FollowLink(GraphicsDeviceManager graphics)
    {
        // Assuming link.xPosition() and link.yPosition() return the center position of Link
        cameraPosition = new Vector2(-Globals.Link.xPosition(), -Globals.Link.yPosition());
        graphicsDeviceManager = graphics;
        UpdateTransform(graphicsDeviceManager);

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
        cameraPosition.X -= units; // Adjust this value as needed
        UpdateTransform(graphicsDeviceManager);
    }

    public void MoveCameraRight(int units)
    {
        cameraPosition.X += units; // Adjust this value as needed
        UpdateTransform(graphicsDeviceManager);
    }

    public void MoveCameraUp(int units)
    {
        cameraPosition.Y -= units; // Adjust this value as needed
        UpdateTransform(graphicsDeviceManager);
    }

    public void MoveCameraDown(int units)
    {
        cameraPosition.Y += units; // Adjust this value as needed
        UpdateTransform(graphicsDeviceManager);
    }
}
