# Tutorial #3   
# Collecting the food and increasing the Snake’s length. # 


#### Step 1 Setting up the Scene

In this tutorial we are going to create a code that will destroy the food object on it’s collision with the snake, and will increase the snake’s length. To do this we have to create a specific tag name for the food element.
Create a new cube/sphere and name it “Food”. Create and attach the material for it. 

Select the food object. 
In the inspector Window, on the very top click on the “tag” droplist and select “Add Tag…”

Click on the plus (+) symbol and name the new tag *“food”.*
Click on the food object and select the tag droplist again. Select the created new tag. 

Open the "prefabs" foulder. Drag there the new food object. Duplicate and place around as many food on the scene, as you like.

Also, in order to make the collision happen, on the Snake’s head should be the Rigidbody component. Also, both head and food should have the colliders. 
So, select the player, go to the Inspector Window and click Add Component button. Start typing “RigidBody” and select it. 
Untick the “Use the Gravity” and tick both “Freeze Rotation” and “Freeze Position” on all three axes. 

#### Step 2 Script for food collection and Snake’s length 

Open the SnakeController script.

Start by creating a new GameObject for the Tail Elements prefabs.
```
   public List<Transform> Tails;
   [Range(0, 5)]
   public float BonesDistance;
   public GameObject BonePrefab; 
    private Transform _transform;
    public float Speed;
    [Range (0, 4)]
```

In the Update event create a new private void for a collision with objects. 
```
 private void OnCollisionEnter(Collision collision)
    {}
```
Next we will create a rule: If we will collide with the object with the object with the tag “food”, this object will be destroyed. 
```
  private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="food")
        {
            Destroy(collision.gameObject); 
        }
```
To create a new element of the tail, we will use the Instantiate method.  We will Instantiate(duplicate) the prefab, which we created earlier. Also,setup the direction for the new position of the prefab to “bone.transform” 

```
  if (collision.gameObject.tag =="food")
        {
            Destroy(collision.gameObject);
            var bone = Instantiate(BonePrefab);
            Tails.Add(bone.transform);
        } 
```
It doesn’t matter, where we will place the new elements, are the MoveSnake void will automatically locate them behind the last element. Save the script and go back to project. 

In the project window->“Prefabs” folder select the cube (tail element) and drag it to the “Bone Prefab” section in the same script component. 
*Play.*


