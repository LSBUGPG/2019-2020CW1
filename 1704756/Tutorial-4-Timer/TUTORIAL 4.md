# **TUTORIAL 4 - Timer**

## Create a New Scene:

Start by creating a new scene called *Tutorial 4*.
We create a `Text Mesh Pro` named *Timer* and we would attached a *script* to it called *Timer*.

## Code:

First of all we need to add a `using TMPro` so the code is able to recognise the `TextMeshPro`.
We are going to create two `public` assets, the first one would be link to the *TextMeshPro* we created before on the scene.
The seconde one is a `float` called *timeLeft*, we are going to use that one to set the ammount of time the timer would run, for this example we are going to set it as `60f`.

``` C#
public TextMeshPro timer;

public float timeLeft = 60f;
```

Next, on the `void Update()` we are going to make the timer go down to 0 and stop.

``` C#
    timer.text = timeLeft.ToString("F0");
    timeLeft -= Time.deltaTime;
```

Last but not least we need to go to our scene in Unity and add a *Mesh Renderer* to out *Text Mesh Pro*. 