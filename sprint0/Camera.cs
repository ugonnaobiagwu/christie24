using System;
using Microsoft.Xna.Framework;
using sprint0;
using sprint0.LinkObj;

public class Camera
{
    /* The Camera now follows Link 
	 * Haven't been able to get the logic behind the screen scrolling but working on it. But use this as a guide :)
	 */

    public Matrix Transform { get; set; }
    public void FollowLink(ILink link, GraphicsDeviceManager graphics)
    {

        // just for readibility reasons:
        int xPosition = -link.xPosition() - (link.width() / 2);
        int yPosition = -link.yPosition() - (link.height() / 2);
        int width = graphics.PreferredBackBufferWidth / 2;
        int height = graphics.PreferredBackBufferHeight / 2;

        var position = Matrix.CreateTranslation(xPosition, yPosition, 0);

        var offset = Matrix.CreateTranslation(width, height, 0);

        Transform = position * offset;
    }


    // implement this
    public void MoveCameraLeft() { }
    public void MoveCameraRight() { }
    public void MoveCameraUp() { }
    public void MoveCameraDown() { }
}