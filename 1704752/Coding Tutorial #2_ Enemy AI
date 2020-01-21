Load up the Tutorial 2d Scene.

##1: Set up the enemy

Add a triangle sprite into the project, and name it "Enemy"

(You can even create two materials in order to add distinctive colour so both characters; 
Right click in the assets box, create material, and change the Albedo colour to be whatever you want.
For this tutorial, I'll make the enemy red. Copy the same steps to make a material for the playe rsprite too.
I'll make the player colour green.)

Now that our enemy is in the scene, it's time to add a script to get it moving.

##2: Coding the enemy movement.

Create a new C# script and call it "EnemyFollow". Open it up!

We're going to make two variables at first, above the Start function.
The first one will be public, meaning we will be able to see it in Unity. This will simply be "public float speed;"
This will of course handle how fast the enemy moves.

The next varaible will be "private Transform player;" This will hold the target our enemy will chase.
In this case, it'll be you, the player!


In the Start function, we want to declare that the target will be a game object with the tag "Player", and its transform information.
So far, your code should look like this:


public class EnemyFollow : MonoBehaviour
{

public float speed;
public float stoppingDistance;
public float retreatDistance;




private Transform player;

    
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;

        
    }


Back in Unity, make sure our player character has the tag "Player" in the inspector.

Back in the script, we'll be writing this "if" statement in the update function:


void Update(){
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance){

        
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);


What this line does is move the enemy from its position, to the player's position, at a certain speed.

"Time.deltaTime" is used to make movement consistent between faster and slower computers.
"transform.position" handles where the enemy is coming from.
"player.position" handles where it's going (towards the player).
"speed" obviously handles how fast it does this.

Overall, your code should look like this so far:



public float speed;
public float stoppingDistance;
public float retreatDistance;

private Transform player;

    
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;

        
    }


    void Update(){
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance){

        
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }


}
}




Hop back into Unity, and add this script onto the enemy. In the Speed bar, add a value of 3 for now.
Hit play and test out the scene, and you should see the triangle chasing the circle!

Now we have a simple enemy following behaviour in our scene! 
However, we can make this more interesting by having the enemy fire bullets at the player, and also stop when it gets too close to the player.

##3: Enemy Retreat.

We're now going to need another "if" statement. In the update function, simply add:

"if(Vector2.Distance(transform.position, target.position) > stoppingDistance){"

This line means the enemy checks its distance between its position, and its target (the player)
and if that distance is greater than the stopping distance we desire, the enemy will continue to pursue the player.
If the distance become smaller than that number, the movement code will stop, and so will the enemy!

Underneath this line, we need an "else if" statement. This will handle what the enemy will do if the enemy's position is LESS THAN the stopping distance.
We'll also make sure the enemy isn't too enar the player; just copy and paste the "Vector2.distance" line, and replace "stoppingDistance" at the end with "retreatDistance"
if these two conditions are met, we need the enemy to stop. Simply add "transform.position = this.transform.position;" 
This will check the player in place over and over again, if the above conditions are met.

We'll add one more "else if" statement, which will handle the enemy retreating.
This code will check if the distance separating the player and the enemy is smaller than our retreat distance value.
copy and paste the "Vector2.distance" line again, and simply change "speed" to "-speed".
Your entire code should look like this now:


    public float speed;
    public float stoppingDistance;
    public float retreatDistance;




    private Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;


    }


    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {


            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance))
        {

            transform.position = this.transform.position;


        }else if (Vector2.Distance(transform.position, player.position) < retreatDistance){

            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

        }
    }
}



Hop back into Unity and enter a value for the stopping and retreat distance, and test this. 
I've gone with Speed 5, Stopping Distance 2 and Retreat Distance 1.5.

Now let's move on to the enemy shooting code!


##4: Enemy Shooting.

Back in the top of our script, before the start function, we need to add some more variables.
I'll start with a private flaot called "timeBtwShots;" and a public float called "startTimeBtwShots;"
Following this, I'll make a public GameObject called "projectile". We'll eventually place the bullet in this, once we go back in Unity.

In the start function, we'll state that "timeBtwShots = startTimeBtwShots;", 
In the update function, make an if statement that checks whether timeBtwShots is less or equal to zero:

"if(timeBtwShots <= 0){"

If it isn't, we will slowly decrease the number by typing in underneath:


} else {
            timeBtwShots -= Time.deltaTime;

Basically, if timeBtwShots is 2, it will take 2 seconds before the value reaches zero.
If timeBtwShots is less or equal to zero, we want the enemy to spawn a projectile, as the time between the shots has ended.
This is super easy!
Simply type "Instantiate" beneath the if statement you just wrote, and inside the brackets, declare what it is we're spawning, at what position and at what rotation.
It' should look like this:

Instantiate(projectile, transform.position, Quaternion.identity);

"Quaternion" basically means no rotation.

Under this, we need to write that "timeBtwShots = startTimebtwShots;" If we don't write this, the enemy will fire every frame!
This is how your entire code should look by now:


 public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimebtwShots;

    public GameObject projectile;
    private Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimebtwShots;
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {


            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance))
        {

            transform.position = this.transform.position;


        }else if (Vector2.Distance(transform.position, player.position) < retreatDistance){

            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

        }

        if(timeBtwShots <= 0){

            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimebtwShots;

            } else {
            timeBtwShots -= Time.deltaTime;
        }
    }
}


Now, we'll jump back in to Unity. From here, we can give the timeBtwShots a value of 2, so it'll fire every 2 seconds.
We also need to make a projectile, and we can do this by simply creating a circle sprite, and making it a colour of your choice. I'm going with yellow.
Rename it "Bullet" to avoid confusion.

Add it in to our scene, and we can make a prefab of it. Do this by selecting it in the inspector, and dragging it back to the project folder.
This has made the sprite a prefab, meaning it can be deleted from our scene and still exist as part of another fucntion.
Simply add this prefab to the projectile section of our enemy script.

Hit play and test the scene. You'll notice that the bullets aren't coming our way. Let's fix that in the next tutorial!
