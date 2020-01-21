# FPSController tutorial

This shows how to make simple First Person Shooter controller. This is a follow on from [Tutorial 1](https://github.com/ie2990/IsabelElia_CW1/blob/master/Tutorial1_StartMenu.md). Please complete that first before proceding onto this one.

## 1. Setting the scene

Start by renaming the scene `SampleScene` to `FPSController`.

Add a 3D Capsule named `Player`, a 3D Plane named `Floor`, and a 3d Cube named `Object`.

In the `Player` inspector, remove the Capsule Collider component and replace it with a `Character Controller` via the Add Component Button. 

Rename the Main Camera to `Eyes` and parent this to the `Player` capsule, ensuring to set all the position values to 0.

Make a new `Blue` material and drag it onto `Object`.

## 2. Creating the script

Create a new C# script and name it `FPSController`.

We’re going to create movement using the W, A, S, and D keys via the `Inputs Axis`. To make this, we need to add some variables. We will be using  the variables `moveLR` and `moveFB` to equate to the value of the virtual axis in the Input. 
We also need to set up `rotX`, `rotY`, and `sensitivity` variables to ensure the character rotates based on the mouse position. 
Also, create a `CharacterController` named `player`, which allows us to store a Character Controller as a variable. 
Creating a public `GameObject` for the camera allows us to lock the rotation to the camera alone. We’ll call this `eyes`. 
  
```
public class FPSController : MonoBehaviour {  

  public float speed = 2f;
  public float sensitivity = 2f; 

  CharacterController player; 
  public GameObject eyes; 

  float moveLR; 
  float moveFB; 
  float rotX; 
  float rotY; 
 }
```

Now we have the variables set up, we need to store the `CharacterController` as a variable at the start of the game, allowing us to change and manipulate that component. 
Using `GetComponent` will only work if the component you are trying to get is on the same object that the script is on. 

```
void Start () {

  player = GetComponent<CharacterController> ();
  
  }
```

## 3. Creating movement

Now that we're all set up, let's create some movement.

Now we will assign the floats we made to the correct Axis. If the W key is pressed the value would equal 1, so we multiply the value by the `speed` to create the movement. 
 
Now that we are monitoring the horizontal and vertical axis, we now want to move the player along that. Creating a new `Vector3` allows us to allocate the X and Z values to the `moveLR` and `moveFB` variables we created.  
The player’s rotation will direct what is forward and backward, so to set this we multiply the rotation by the new `Vector3` movement we just created. 
Using the `CharacterController` variable of `player` that we created earlier, we now want to set the movement of the Player using `Time.deltaTime.`

```
void Update () { 

 moveLR = Input.GetAxis(“Horizontal”) * speed; 
 moveFB = Input.GetAxis(“Vertical”) * speed; 
 
 rotX = Input.GetAxis(“Mouse X”) * sensitivity; 
 rotY = Input.GetAxis(“Mouse Y”) * sensitivity; 
 
 Vector3 movement = new Vector3 (moveLR, 0, moveFB); 
 transform.Rotate (0, rotX, 0);

 movement = transform.rotation * movement; 
 player.Move (movement * Time.deltaTime); 
 
 } 
```

Now that we have the movement, save and select attach to unity. 
Switch back to Unity and press play. The `Player` should now move when pressing either the arrow keys or WASD. 
The camera should also move from left to right.

The `speed` and `sensitivity` variable should now show in the inspector, and can be altered to whatever value you would like.

Drag and drop the Main Camerea `Eyes` from the hierachy to the empty slot for `eyes` in the FPSController script in the Inspector to allocate the game object.

## 4. Camera movement

As tested, the player can only rotate the camera left and right using the mouse, but not up and down. Using the Game Object `eyes` we created earlier we can fix this.

Add this line to the `Update` function:

```
 eyes.transform.Rotate (-rotY, 0, 0); 
```

Save and Attach to Unity.

## 5. Back to Unity Editor

Switching back to the Unity Editor, It's now time to see how the script works.

Press play and move the character and mouse. Test the camera and player movement, and also try walking into the blue `Object` cube to ensure you are colliding with it with no problems.
