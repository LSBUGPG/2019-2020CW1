# **TUTORIAL 1 - Character Movement**

## Create a New Scene:

Start by creating a new scene called *Tutorial 1*.
Add a 3D `capsule` named *Player* to the scene.
Create a new *Script* called *Movement* that would be attached to the *Player*.

## Coding the Movement:

On the previously created script we are going to create a `public float` called `horizontalSpeed` so we can edit the speed of our character every time from the scene until we get the one that suits us better.
As we are going to move our character with the mouse, we create a `private float` called `mouseX` so we have the control of the axis.

Now that we have our first assets ready, we add the movement to the character:
``` C#
    mouseX = horizontalSpeed * Input.GetAxis("Mouse X");
    Vector3 newPosition = new Vector3(mouseX, 0f, 0f);
    transform.position += newPosition;
```

This lines of code are included on the  `void Update ()`. Essentially we are telling the code to keep our keep our player static on the Y and Z position while the X axis would be guided by the movement of the mouse and controlled by the speed that we decide, on this case, our Horizontal Speed would be `0.3f`.

## Stop the Player

What we are going to do now is to stop the player to go further certain point on the screen, so it always remains on the scene. 
``` C#
    if (transform.position.x >= 5.2f)
    	{
        	transform.position = new Vector3(5.2f, transform.position.y, transform.position.z);
    	}

    if (transform.position.x <= -5.2f)
		{
    	    transform.position = new Vector3(-5.2f, transform.position.y, transform.position.z);
    	}
```
As you can see, we are telling the code to stop if the position of the *Player* is `5.2f` or `-5.2f`. We don’t need to change the Y or Z postion as we already told the code to always remain at the same postion.