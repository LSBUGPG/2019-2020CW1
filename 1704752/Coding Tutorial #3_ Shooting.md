##1: Targeting.

We'll need to make a new script to handle the targeting of the bullets. Let's call it "Projectile". Open it up.

I'll go over the code, but it should look like this:


public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    void Update() {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    }

This basically means the player will spawn a projectile that chases any object with the tag of "Player".
It will be targeted to the player's position, as soon as it's spawned. It will continue to move towards that point, even if the player has moved.

We need to add some code to destroy the proejctile once it reaches its target, and if it hits the player. Here's how that should look:

if(transform.position.x == target.x && transform.position.y == target.y){
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            DestroyProjectile;
        }

    }

    void DestroyProjectile() {

        Destroy(gameObject);
    }

    }


What's happening here is: 

"void DestroyProjectile" is adding a function to destroy the proejctile.

" if(transform.position.x == target.x && transform.position.y == target.y){
            DestroyProjectile(); " is calling on the code to destroy the bullet if it reaches a certain position.

"void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            DestroyProjectile;" is destroying the bullet if it collides with the player's trigger box, as it has the tag of "Player"

Let's hop back to Unity!
Ensure that the player has a Rigidbody2D attached, as well as a circle collider.
In the bullet prefab, add the projectile script, and a circle collider too. Make sure the collider has trigger ticked, and remember to give the bullet speed a vlaue!
I've made mine 15, but this can be changed as you see fit.

Here's the entire script, and how it should look:


public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    void Update() {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y){
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            DestroyProjectile();
        }

    }

    void DestroyProjectile() {

        Destroy(gameObject);
    }

    }

That's all for this tutorial!
