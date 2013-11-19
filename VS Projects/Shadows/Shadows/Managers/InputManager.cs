using System;

using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Shadows.Managers
{
    /// <summary>
    /// The InputManager allows the game to accept input from a number of sources, including
    /// gamepads and keyboards. Future implementations may allow use of a touch screen device.
    /// </summary>
    class InputManager
    {
        private static GamePadState previousPadState;

        public static int GetInput()
        {
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            int currentDirection = 0;

            if (gamePadState.IsConnected)
            {
                currentDirection = ControllerInput(gamePadState);
            }
            else if (gamePadState.IsConnected && !previousPadState.IsConnected)
            {
                Debug.WriteLine("Controller Connected");
            }
            else if (!gamePadState.IsConnected && previousPadState.IsConnected)
            {
                Debug.WriteLine("Controller Disonnected");
                // Pause the game!
            }
            else
            {
                currentDirection = KeyboardInput();
            }

            previousPadState = gamePadState;
            return (int)currentDirection;
        }

        private static int KeyboardInput()
        {
            int currentDirection = 0;

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Up))
                currentDirection = 1;

            if (keyState.IsKeyDown(Keys.Down))
                currentDirection = 2;

            if (keyState.IsKeyDown(Keys.Left))
                currentDirection = 3;

            if (keyState.IsKeyDown(Keys.Right))
                currentDirection = 4;

            return currentDirection;
        }

        private static int ControllerInput(GamePadState gamePadState)
        {
            int currentDirection = 0;

            KeyboardState keyState = Keyboard.GetState();

            if (gamePadState.ThumbSticks.Left.Y <= 1 && gamePadState.ThumbSticks.Left.Y > 0)
                currentDirection = 1;

            if (gamePadState.ThumbSticks.Left.Y < 0 && gamePadState.ThumbSticks.Left.Y >= -1)
                currentDirection = 2;

            if (gamePadState.ThumbSticks.Left.X < 0 && gamePadState.ThumbSticks.Left.X >= -1)
                currentDirection = 3;

            if (gamePadState.ThumbSticks.Left.X <= 1 && gamePadState.ThumbSticks.Left.X > 0)
                currentDirection = 4;

            return currentDirection;
        }
    }
}
