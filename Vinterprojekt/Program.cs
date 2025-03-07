using Raylib_cs;

using System;
using System.Numerics;

// Import necessary libraries
// Raylib_cs is used for graphics and audio

// Define main class ShapeDrawingGame
// Initialize window with size 800x600 and title "Shape Drawing Game"
// Set target FPS to 60

// Declare variables:
// shapeInput - stores user input for shape selection (initially empty)
// shapePosition - stores position of shape (set to center of screen)
// shapeColor - sets default shape color to Blue
// shapeDrawn - boolean to track if a shape is drawn
// invalidShape - boolean to check for invalid input
// invalidShapeTimer - timer to display invalid shape message

// Initialize audio device and load background music "taco.ogg"
// Play the music

// Variable annoy initialized to 0 (used for user response handling)

// Main game loop (runs until window is closed)
    // Update music stream and set volume to maximum
    
    // Check if shape is not drawn (input mode)
        // Get character input from keyboard
        // Append characters to shapeInput if valid ASCII value
        // Handle backspace key to remove last character
        
        // If Enter key is pressed:
            // Check if shapeInput is not empty
                // Set shapeDrawn to true
            
            // Handle special cases of input (e.g., "nah")
                // Increase annoy variable
                // Display message to encourage drawing
    
    // Start drawing phase
    // Clear background with white color
    
    // Display input instructions if no shape is drawn
    // Display user input as text
    
    // If shapeDrawn is true, check input and draw corresponding shape
        // If input is "circle", draw a circle
        // If input is "rectangle", draw a rectangle
        // If input is "triangle", draw a triangle
        // If input is "square", draw a square
        
        // Handle responses for non-shape inputs
            // Display message based on user input (e.g., "no", "nah", etc.)
            
        // If shape input is invalid, start invalid shape timer
    
    // If Tab key is pressed, reset input and allow new shape entry
    
    // If invalidShape flag is set, display "Invalid shape!" message for 1.5 seconds
        // After 1.5 seconds, reset input and shapeDrawn flag
    
    // End drawing

// Close the window when the game loop ends



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
