# Making a dissolve shader in Unity
### 1. Setting up Unity
> To begin, create a new scene in unity. There are some things we're going to need to import via the package manager, so go to Windows -> Package Manager.

> Download the Lightweight RP and Shader Graph and import them into your project.

> Right click in the assets folder and go to Create -> Rendering -> Lightweight Render Pipeline -> Pipeline Asset

> Go to Edit -> Project Settings -> Graphics and drag the Pipeline Asset you just created into the first box at the top.

> Create a cube and adjust the camera so that the cube is in view.

> Create a new material and name it "dissolve". Assign it to the cube.

> Create the shader by right clicking in the project view and going to Create -> Shader -> PBR Graph. Name it whatever you want.

> Click on the dissolve material and assign the shader to it by clicking on the shader dropdown menu and going to ShaderGraphs -> DissolveShader (or whatever you named the shader).
> The cube should now have the dissolve shader attached to it.

### 2. Editing the shader
> Open up the shader you just created and there should just be one node called "PBR Master". This is what controls the shader's properties.

> Right-click in empty space, and type in "Simple noise" to make a noise component. Change the X property to 30. Click and drag from the out component of
> The node and connect it to the "Alpha" input of the PBR Master node. This makes the alpha of the material scattered.

> Create a Remap node. Drag its out component to the "AlphaClipThreshold" component of the PBR Master node.

> Create a Time node. Plug its Sine Time component into the In component of the Remap. This will make it so that the Remap's component alternates between black and white.

> The AlphaClipThreshold determines the alpha level at which Unity will make an object transparent. Because of the noise component and the varying shades, it looks like the object is dissolving.

> Now that we've got the dissolving to happen, we want there to be a bit of glowing at the edges to emphasize the effect.
> To do this, create an Add node. Set the X input value to be 0.3, and connect the "Out" of the Remap component into the other input of the Add component.

> Create a step component. Drag the output of the Simple Noise component and connect it to the Edge input of the Step. Drag the output of the Add component into the In of the Step node.

> At this point, you could plug in the step to the master emission but we wouldn't be able to change the color. To do this, create a multiply node and a color node.
> plug the color node into one of the inputs of the multiply. Plug the output of the Step node into the other multiply input. 

> After this, plug the output of the multiply node into the emission of the PBR Master Node. The multiply node takes the color of the 

> If you go into the Unity editor, the cube should be dissolving in and out over time if you hit Play.

### 3. Customizable Inputs
> We need to make it so that we don't have to open up the PBR graph every time we want to change something about the shader.

> To finish up, find the box with the name of the shader around the top left-hand corner. Click the plus button and add a color. Plug the out component of the color into the color node on the graph. This will let us customize the color of the edge pieces.

> Next, add a float parameter the same way you added the color. Plug this one into the scale input of the Simple Noise node. This will let us customize the size of the particles.

> Add another float. Plug this one into the numbered input of the Add node. This will let us customize the edge width.

> You can rename these parameters to reflect what they represent, then return to the unity editor. That's it!
