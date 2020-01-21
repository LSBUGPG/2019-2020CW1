# Walkthrough 1: Distance UI

1. Create a *Canvas* via right clicking in your *Hierarchy* then selecting UI>*Canvas*

2. Create a *Text* GameObject via the same menu above, selecting UI>*Text*. It should appear as a child of the *Canvas*. Reposition and resize as desired.

3. Select the *Text* GameObject in the *Hierarchy*. In the *Inspector* panel, click *Add Component* and type *DistanceUI* and then create a *new script* and open it.

4. At the very top of the script, under

        using UnityEngine;

    add

        using UnityEngine.UI;

This gives us the ability to the interact with the UI Components Unity uses.

5. Next, above the *Start* function, we need to declare some *properties*:

        public Transform position1;
        public Transform position2;
        public int decimalPlaces;
    	Text textComponent;

Back in the *Unity Editor* we need to assign the first 3 properties. The first 2 are the objects you want measure the distance between. Drag and drop those from the *Hierarchy*. The 3rd property is the number of *decimal places* the distance should be rounded to. This number should be from 0 to 15 (inclusive).

6. *Inside* the *Start* function we need to add:

      textComponent = GetComponent<Text>();

The this line finds the *Text Component* on the GameObject and assigns it to the *textComponent* property.

7. *Inside* the *Update* function we need to add:

      textComponent.text = System.Math.Round(Vector3.Distance(position1.position, position2.position), decimalPlaces).ToString() + "m";

Let's dissect that line.

      textComponent.text =
            - Access the *text property* of *textComponent* and tell it to *equal* what we do next

        System.Math.Round(,)
            - The number we put in the brackets *before* the comma is the number we want to round.
            - The number we put *after* the comma is how many decimal places we want the number rounded to.

        Vector3.Distance(,)
            - The *Distance function* belonging to the *Vector3 class* calculates the distance between 2 position in 3D space. These positions are represented by the Vector3 class, which contains properties for the *x,y and z axis*.

        position1.position, position2.position
            - The properties we assigned earlier contain their own *Vector3 property* called *position* which we can access and use for the *Distance* method above.

        ToString()
            - Everything prior to this resulted in us calculating a *number* (the distance). The *text property* from the beginning of the line *needs* to be a *string*, thus this section serves to convert the number into a string.

        + "m"
            - This part adds the metre denominator *m* to the string. It is entirely optional.

# Conclusion & Final Notes
This is a simple and concise way to calculate and display the distance between 2 objects.

When determining the size (Width & Height) of your Text GameObject, it helps to temporarily fill it with the content you expect to see (via the *Inspector*). For example in this project you might use *10.91m* as a placeholder.

For a better looking result, you can align the text to the right. This will stop the text jumping around and keep the *m* denominator fixed in place. The alignment can be changed in the *Inspector* or by adding:

    textComponent.alignment = TextAnchor.MiddleRight;

...to the *Start* function after assigning *textComponent*.
