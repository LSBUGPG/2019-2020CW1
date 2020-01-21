In the following tutorials we are going to create a basic snake game. 
# Tutorial 1 - Snake Movement.


##### Step 1 Setting up the Scene


Create a new 3D Project. 
Create a new 3D Object - Plane. 
*This object is going to be the playing area.*
Duplicate that Plane and scale it, so it is visibly more significant than the first one.
*This will be a background behind the playing board.*
In the project window, Create a new folder named “Materials”. 
Create two new Materials and attach them for both created objects.

Create a new 3D Object - Cube. Scale it to the same length as the playing board. 
In the Inspector Window scale the Z-Axis (width) by 2 and the height (Y-Axis) by 10. 
Move it to the edge of the playing area. *Those would be borders.* 
Duplicate and place another border on the opposite side. 
Repeat two more times, duplicate and rotate the borders and put them on remaining sides of the playing area. 

Select the camera and move in the centre of the board by resetting the Transform Component. Rotate the camera and move the camera until the board is fully visible and you are happy with the result.

##### Step 2 Snake Movement.

Create a small cube, create and set new Material for it. Rename the cube to the “Snake”. 
*This would be the movable and controllable head of the snake.*

Start by creating a new Folder “Scripts”. Create script named ***SnakeController.***

Click on the “Snake” cube, lock its Inspector window and drag the Snake Controller Script to the Inspector. 

Open the script. 

Start by adding a private component Transform. 
This component will allow manipulation with the snake, by moving and rotating it. 

```
public class SnakeController : MonoBehaviour
{
    private Transform _transform;
```



In the same class add the public float named Speed, which will allow changing the snake’s speed directly from the inspector window. 
Also, create the Range component, which will create a smooth speed slider.



    public class SnakeController : MonoBehaviour
    {
    private Transform _transform;
    public float Speed;
    [Range (0, 4)]



In a way to access Transform component, add the “GetComponent” element in the Start Event. 



    public class SnakeController : MonoBehaviour
    {
    private Transform _transform;
    public float Speed;
    [Range (0, 4)]
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }


To make the snake move forward, we need to create a private void MoveSnake in the Update Event. 



    private void Update()
    {
        private void MoveSnake(Vector3 newPosition)
         {
        _transform.position = newPosition;
         }
    } 


In Update Event, we have to create the rule for the MoveSnake void. To move the snake to its current position will be added the vector of the forward-going axis and the speed.


    private void Update()
    {
        MoveSnake(_transform.position + _transform.forward * Speed);
    }
    private void MoveSnake(Vector3 newPosition)
    {
        _transform.position = newPosition;
    }





To rotate the snake’s head, we need to calculate its angle of rotation. In Unity, we can use the method of GetAxis of the Input class. 
Horizontal Axis will create value will be in the range -1...1 for keyboard, where the [D] will be -1 (Left) and [A] will be 1 (Right). 
Finally, add the rotation, which will change by the Horizontal Axis.



    private void Update()
    {
        MoveSnake(_transform.position + _transform.forward * Speed);
        float angle = Input.GetAxis("Horizontal") * 4;
        transform.Rotate(0, angle, 0);
    }
    private void MoveSnake(Vector3 newPosition)
    {
        _transform.position = newPosition;
    }

Save the script. The snake is now moving and turning around.
