# **TUTORIAL 2 - Character Movement**

## Create a New Scene:

Start by creating a new scene called *Tutorial 2*.
We used the `Create Empty` named *Spawner* to the scene.
Create a new *Script* called *Spawner* that would generate an object (a *cube*), on a random position, this object would be saved as a *prefab*.

## Coding the Parameters:

On the previously created script, we are going to create a `public Game Object` called *Objects* so we can add a different object, a *cube* on this case, as the object we want to generate.
Secondly we create a `private float` called *spawnTime* and we are going to set the time at `3f` so the object would spawn every 3 seconds.

At the `void Start` we are going to add the line of code that would repeat the process of spawning objects.

``` C#
    InvokeRepeating ("Spawn", spawnTime, spawnTime);
```

## Radomized Position:

Now we need to set the position of the spawner and the range on the axis where the objects would randomly appear. 
``` C#
    float spawnPointX = Random.Range (-10f, 12f);
    Vector3 spawnPosition = new Vector3(spawnPointX, 0.12f, 0.5f);
```
Last but not least, we are going to add a `Instantiate` so the object would create copies of itself.
``` C#
    GameObject spawn = Instantiate (Objects, spawnPosition, Quaternion.identity);
```