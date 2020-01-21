Start by making a new 2D project.

##1: Setting up the scene

Add a new 2D Circle Sprite and name it 'Player'. Drag it into the scene.

Next, create a c# script and call it 'PlayerController'. Drag and drop it on to the Player.

Double click the script to open it up.


##2: Movement Coding



Frist of all, above the start function, make a public float called 'speed'; this will handle how fast our character can move around. 
After that, to add physics to the character, we need to give it a Rigidbody 2D. Declare it as a private varaible.
It'll look something like this:


public class PlayerController : MonoBehaviour{

    public float speed;

    private Rigidbody2D rb;

}


Next, inside the Start function, we need to declare that the 'rb' variable is equal to the Rigidbody component that we'll eventually attach to our player.
It should look like this:


void Start(){

        rb = GetComponent<Rigidbody2D>();

    }

With this code written, head back into Unity, select the Player and add a 'Rigidbody2D' component to it.
Select the drop down that says 'Dynamic', and change it to 'Kinematic'. This will stop our player being affected by gravity.

After this, head back into the script. In the 'Update' function, we need to add the code for movement input. 
This segment will take care of the values of moving left and right, and up and down using Vector2, and horizontal and vertical inputs. It should look like this:

void Update(){

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }

Going back to the start of the script, underneath 'private Rigidbody2D' we'll need to write a new Vector 2 variable called 'moveVelocity'. 
Add this to your update function as equal to 'moveInput * speed;' In order to regulate diagonal movement, simply write '.noramlized' after moveInput.

At this point, here is how your whole script should be looking:

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start(){

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update(){

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }
}


##3: Getting the Player Moving

In our Update function, we need to add values to our player in order to get them moving. Add function called 'FixedUpdate'.
All code relating to adjusting physics should go in here.
Inside the function, declare the rigidbody of our player, 'rb', state its position and '+moveVelocity' to make it able to move. Multiply this by 'time.fixedDeltaTime.'
This sends the player in the direction in which the input prompts it to, as stated in our previous lines of code.
FixeddeltaTime is affected by the physics of the game, 
it should look like this:

 void FixedUpdate(){

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }


Hop back into Unity, and select the Player. The player controller script should now have a 'speed' variable that can be adjusted. Give it a value of 10.
Pres the play button and test your game! The character can now move around the screen.

In order to refine the movement, jump back into the code. We're going to change the 'GetAxis' section of the update function to 'GetAxisRaw'.
This will give our player much snappier movement, and will stop moving as soon as we let go of the button. Do this for both the X and the Y Inputs!
Jump back into Unity, press play, and you'll see that the player moves in a much more controlled manner.

Here's how the entirety of your code should look:


public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start(){

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update(){

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate(){

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }
}


That concludes the tutorial on 2D top down movement!
