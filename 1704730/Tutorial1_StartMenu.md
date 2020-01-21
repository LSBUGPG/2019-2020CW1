# Main Menu Tutorial

This shows how to create a simple main menu with a function to play the game.

## Create a new Scene

Create a new scene called `StartMenu`.

## Setting Up the UI

Right-click in the Hierachy and scroll over `UI`, and then select `Panel`. Rename the `Panel` to `Background`. Rename the `Canvas` to `MenuOptions`.

In the `Background` inspector, select the `Color` under the Image component and drag the alpha channel up to 100. Here you can select a colour. If you want to add your own image to the background rather than a plain colour, simply save the image to the Assets folder, check in the inspector that the Texture Type is set to `Sprite (2D and UI)`, drag the image into the `Source Image` tab in the Image component, and ensure that the Alpha chanel is at 100 too.


## Creating the Play button

Right-click on the Hierachy and go to UI>Button. Resize and reposition this button however you would like. In the hierachy, rename the button to `PlayButton`. 

In the inspector under `Image`, change the colour of the button to black. As we want it to indicate to the player that it is in fact a button, we are going to alter it's colour based on different variables. When the button is not being interacted with, it will not show, so under `Normal Color` in the `Button (Script)` component change the alpha channel to 0.

When the button is hovered over with the cursor, we want the button to be visable, but not fully opaque. To do this, change the `Highlighted Color` to 60 in the alpha channel.

Finally, when the button is selected, we want the button to be even clearer. We do this by changing the `Pressed Color` alpha channel to 100.

In the inspector, simply change the "New Text" in the `Text Input Box` to `Play`. You can edit and adjust the text here, so feel free to play around and make it look nice.

## Making the button do something

Press play and test the button.

The `Play` button does not do anything when clicked on, but should show the colours we just created.

Select the `MenuOptions` canvas and then add component. Create a new C# Script called `Menu`.

In this script we will start by removing the `Start` and `Update` method and create our own method. When you want to change scenes, you must always use `UnityEngine.SceneManagement` in order to access `SceneManager`.

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
 public void PlayGame () 
 {
  SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
 }
}
```

Save and attach the script to Unity.


## Finalising in Unity

Now we have the code all set up, we need to order the queue in which Unity moves between scenes.

Go back into Unity and select `File`>`Build Settings`.

Drag the `StartMenu` scene from the project window into the Scene Manager window. Then repeat this for the scene you wish to play next. In this case we only have the `SampleScene` that is given to us by default, so we are going to use this for the purpose of the tutorial, however you should use the actual game scene you have created.

Close out of the window once that is completed and select the `PlayButton` in the Hierachy. In the inspector, find the the list `OnClick` under the header `Button (Script)`. Click on the plus button and drag the `MenuOptions` object into the empty slot. Select the drop down list `No Functions` and select `Menu` > `PlayGame ()`.

Play the game and test to see if it works!










