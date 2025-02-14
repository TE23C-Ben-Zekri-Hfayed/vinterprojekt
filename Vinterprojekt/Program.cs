using Raylib_cs;

using System;
using System.Numerics;

class ShapeDrawingGame
{
    static void Main()
    {
        Raylib.InitWindow(800, 600, "Shape Drawing Game");
        Raylib.SetTargetFPS(60);

        string shapeInput = ""; // input text, make sure it's empty.
        Vector2 shapePosition = new Vector2(400, 300);
        Color shapeColor = Color.Blue;
        bool shapeDrawn = false;
        bool invalidShape = false;
        float invalidShapeTimer = 0f; // Timer for invalid shape

        Raylib.InitAudioDevice();
        Music background = Raylib.LoadMusicStream("taco.ogg");
        Raylib.PlayMusicStream(background);

        int annoy = 0;
        while (!Raylib.WindowShouldClose())
        {
            Raylib.UpdateMusicStream(background);
            Raylib.SetMusicVolume(background, 1f);
            // Input mode
            if (!shapeDrawn)
            {
                // Get text input
                int key = Raylib.GetCharPressed();
                while (key > 0)
                {
                    if ((key >= 32) && (key <= 125))
                    {
                        shapeInput += (char)key;
                    }
                    key = Raylib.GetCharPressed();
                }

                // Backspace handling
                if (Raylib.IsKeyPressed(KeyboardKey.Backspace))
                {
                    if (shapeInput.Length > 0)
                        shapeInput = shapeInput.Substring(0, shapeInput.Length - 1);
                }

                // Submit shape when Enter is pressed
                if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                {
                    
                    if (!string.IsNullOrWhiteSpace(shapeInput))
                    {
                        shapeDrawn = true;
                    }

                    switch (shapeInput.ToLower())
                    {
                         case "nah":
                         annoy++;
                        Raylib.DrawText("You're not cute, draw something.", 20, 50, 30, Color.Black);
                        Raylib.DrawText("Press TAB to draw.", 20, 10, 30, Color.Red);
                        break;
                    }
                }
            }

if (annoy >= 4)
{
     
}
            // The reset.
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            // Draw input instructions
            if (!shapeDrawn)
            {
                Raylib.DrawText("Type a shape (circle, rectangle, triangle, square):", 50, 50, 20, Color.Black);
                Raylib.DrawText(shapeInput, 50, 100, 30, Color.Black);
            }

            // draw shape moment, if included.
            if (shapeDrawn)
            {
                switch (shapeInput.ToLower())
                {
                    case "circle":
                        Raylib.DrawCircle((int)shapePosition.X, (int)shapePosition.Y, 100, shapeColor);
                        Raylib.DrawText("Press TAB to draw again.", 20, 50, 30, Color.Red);  // Put before break to start over.
                        break;
                    case "rectangle":
                        Raylib.DrawRectangle((int)shapePosition.X - 30, (int)shapePosition.Y - 50, 150, 100, shapeColor);
                        Raylib.DrawText("Press TAB to draw again.", 20, 50, 30, Color.Red);
                        break;
                    case "triangle":
                        Vector2 v1 = new Vector2(shapePosition.X, shapePosition.Y - 60);
                        Vector2 v2 = new Vector2(shapePosition.X - 80, shapePosition.Y + 80);
                        Vector2 v3 = new Vector2(shapePosition.X + 80, shapePosition.Y + 80);
                        Raylib.DrawTriangle(v1, v2, v3, shapeColor);
                        Raylib.DrawText("Press TAB to draw again.", 20, 50, 30, Color.Red);
                        break;
                    case "square":
                        Raylib.DrawRectangle((int)shapePosition.X - 50, (int)shapePosition.Y - 50, 100, 100, shapeColor);
                        Raylib.DrawText("Press TAB to draw again.", 20, 50, 30, Color.Red);
                        break;
                    case "a shape":
                        Raylib.DrawText("Not 'a shape'", 20, 50, 30, Color.Black);
                        Raylib.DrawText("Press TAB to draw.", 20, 10, 30, Color.Red);
                        break;
                    case "no":
                        Raylib.DrawText("What do you mean no? Draw.", 20, 50, 30, Color.Black);
                        Raylib.DrawText("Press TAB to draw.", 20, 10, 30, Color.Red);
                        break;
                    case "me no wanna :(":
                        Raylib.DrawText("You're not cute, draw something.", 20, 50, 30, Color.Black);
                        Raylib.DrawText("Press TAB to draw.", 20, 10, 30, Color.Red);
                        break;
                    case "me no wanna":
                        Raylib.DrawText("You're not cute, draw something.", 20, 50, 30, Color.Black);
                        Raylib.DrawText("Press TAB to draw.", 20, 10, 30, Color.Red);
                        break;
                    case "nah":
                        Raylib.DrawText("Stop being a jackass, just listen to me.", 20, 50, 30, Color.Black);
                        Raylib.DrawText("Press TAB to draw.", 20, 10, 30, Color.Red);                        
                        break;
                    case "i dont want to":
                        Raylib.DrawText("Draw something NOW!", 20, 50, 30, Color.Black);
                        Raylib.DrawText("Press TAB to draw.", 20, 10, 30, Color.Red);
                        break;
                    case "okay":
                        Raylib.DrawText("okay well do it.", 20, 50, 30, Color.Black);
                        Raylib.DrawText("Press TAB to draw.", 20, 10, 30, Color.Red);
                        break;






                    default:
                        // Start the timer when an invalid shape is detected
                        if (!invalidShape)
                        {
                            invalidShape = true;
                            invalidShapeTimer = 0f;
                        }
                        break;
                }

                // Check if Tab is pressed to reset
                if (Raylib.IsKeyPressed(KeyboardKey.Tab))
                {
                    shapeDrawn = false;
                    shapeInput = "";
                }
            }


            // If an invalid shape was entered, display the "Invalid shape!" message for 1.5 seconds
            if (invalidShape)
            {
                invalidShapeTimer += Raylib.GetFrameTime(); // Increase the timer
                Raylib.DrawText("Invalid shape!", 50, 200, 30, Color.Red);

                // If 1.5 seconds have   passed, reset
                if (invalidShapeTimer >= 1.5f)
                {
                    invalidShape = false;
                    shapeInput = "";
                    shapeDrawn = false;
                }
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
