# **TUTORIAL 3 - Object Moves Towards the Player**

## Create a New Scene:

Start by creating a new scene called *Tutorial 3*.
We used the `Create Empty` named *Spawner* to the scene as we did on a previous tutorial.
And also a *Cube* which would be the object that we are spawning.
We need to create a character as well so we also are going to use the same assets as we did on a previous tutorial.
Now we are going to create a new *Script* called *Object*, this object would be saved as a *prefab*.

### Previous Code

Player:
``` C#
    public class Movement : MonoBehaviour {
    public float horizontalSpeed;
    private float mouseX;

    void Start () 
    {
		
    }
	
    void Update () {
	mouseX = horizontalSpeed * Input.GetAxis("Mouse X");
    Vector3 newPosition = new Vector3(mouseX, 0f, 0f);
    transform.position += newPosition;

		if (transform.position.x >= 5.2f)
    	{
        	transform.position = new Vector3(5.2f, transform.position.y, transform.position.z);
    	}

    	if (transform.position.x <= -5.2f)
		{
    	    transform.position = new Vector3(-5.2f, transform.position.y, transform.position.z);
    	}
	}
}
```
Spawner:
``` C#
public class Spawner : MonoBehaviour {
public GameObject Objects;
private float spawnTime = 3f;

	void Start () 
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	void Spawn () 
	{	
		float spawnPointX = Random.Range (-10f, 12f);
		Vector3 spawnPosition = new Vector3(spawnPointX, 0.12f, 0f);

		GameObject spawner = Instantiate (Objects, spawnPosition, Quaternion.identity);
	}
}
```
## Coding the Target:

For the target we are going to create a `public Transform` calles *target* so we can attached anything on the scene, the `mainCamera` on this case.

The object that we are spawning would go towards the *MainCamera*, to be able to do this, we are going to use a `vector 3`.

``` C#
    transform.position = Vector3.MoveTowards(transform.position, target.position, step);
```
Also, we are going to have a variable called *speed*, for that we are going to create a `public float`. A new `float` called step would be needed (step is mention before ojn the `transform.position` line of code).

``` C#
    float step = speed * Time.deltaTime;
```

## Collisions:

Our character would interact whith the objects that are spawning, mention interactivity would make the objects dissapear, both with the *Player* or the *Main Camera*. Both lines of code are really similar as both has the same effect on the objects.
``` C#
    void OnCollisionEnter (Collision col)
    {

    if (col.gameObject.tag == "MainCamera")
        {
            Destroy (gameObject);
        }
```
``` C#
    if (col.gameObject.tag == "Player")
        {
            Destroy (gameObject);
        }
    }
```

To make this work we would need to add a *Rigidbody* to the *Player* and the *Object* previously saved as a *prefab*.
Also, a *collider* would be needed on the *Main Camera* so the objects dissapear from the scene after hitting it.