
 **Overview**
 --------
- *What are you making?*

**Understanding and Configuring Ragdolls in Unity**

Setting up and understanding ragdolls in Unity involves managing numerous factors that impact their performance. Achieving proper functionality requires an iterative approach, experimenting with the configuration of each joint connector, adjusting forces, and balancing the weight of individual limbs. Equally important is calibrating the weight of objects the character interacts with and fine-tuning the material friction for smooth and realistic movement. This process demands extensive testing and frequent adjustments, making it a detailed and hands-on exploration.
 

 ----------------
**Objective Statement**
-----
- *What question are you trying to answer with your prototype? Why?*


Can early education be approached with a new game design perspective? Based on this concept, let's analyze what kind of advantages or disadvantages the use of electronic devices at an early age might bring. Although this situation has significantly intensified recently, it could be a great opportunity for careers like game design to change the current approach. Instead of focusing on whether it’s good or bad, since it’s something that is already happening, we could improve the usability of these types of applications to be educational and fun. This could be implemented across other areas, creating new learning methods for all ages and all careers—not just limited to early childhood or gaming platforms.

--------
**Design Rationale**
-----
- *What do you envision? How is the game experience informed by metrics? How is it engaging beyond a simulation?*

I want it to be a game where you can learn in a chaotic way. This way, the player will be forced to pay more attention to how they move, trying to maintain control of their character and the controls, paying greater attention to the situation. The game features loose controls and ragdoll physics, blending realistic gravity with exaggerated character movement. The mechanics rely on physical properties while maintaining a playful tone. Likewise, the elements that players will move and place around the map will have properties such as gravity, momentum, collision response, and force application.

-----------
**Metric Research and References**
-----

 - *What real-world information are you leveraging to inform objects
   scale, weight, friction, etc?*

**Genre : Physics Puzzle/Platformer**

**Engine :**

**Unity using Ragdoll physics**

Ragdoll physics are a set of colliders, rigid bodies and joints that you can apply to a humanoid character, to simulate behaviour such as impact collisions and character death.


[https://docs.unity3d.com/6000.0/Documentation/Manual/wizard-RagdollWizard.html](https://docs.unity3d.com/6000.0/Documentation/Manual/wizard-RagdollWizard.html)

---
**Human biomechanics**

“Biomechanics is the science of the movement of a living body, including how [muscles](https://www.verywellfit.com/will-i-get-big-legs-from-walking-3435392), bones, [tendons](https://www.verywellfit.com/achilles-tendon-stretches-3120291), and ligaments work together to move. Human biomechanics focuses on how forces act on the musculoskeletal system and how the body tissue responds to these forces.”  

**I’m going to focus on the external biomechanics:  
**  
External biomechanics describes external forces on body segments and their effect on body movement

1.  **Static**: describes mechanics that analyse the bodies at rest or in uniform motion

2. **Dynamics:** the study of conditions under which an object moves.

------
**Contact force:** 
  
  It occurs when two objects are in contact with each other. The forces between them can be resolved into normal force reactions and friction.

**Normal force** - the force is perpendicular to the surface in which two objects are interacting.

**Friction** - the force acting on parallel surfaces.


[**https://www.youtube.com/watch?v=1pbGP-MRN-0**](https://www.youtube.com/watch?v=1pbGP-MRN-0)[**https://www.youtube.com/c/Bassettbiomechanics/videos**](https://www.youtube.com/c/Bassettbiomechanics/videos)[**https://github.com/modenaxe/awesome-biomechanics**](https://github.com/modenaxe/awesome-biomechanics)[**https://www.youtube.com/watch?v=OL4WWoWVgAs**](https://www.youtube.com/watch?v=OL4WWoWVgAs)

-----
**Drag (physics)**  
[https://www.sciencefacts.net/drag-force.html](https://www.sciencefacts.net/drag-force.html)

“Drag tends to slow down the object”  
“Drag is a physical force that opposes the motion of an object through a fluid, such as air or water.  In Unity, drag is used to simulate how objects slow down as they move through a medium, creating more realistic physics interactions.”

***ways to use it in unity:**  
Drag is applied with rigidbody component. That determinates how much resistance an object experiences when it moves. you can simulate resistance in a variety of scenarios.  
**Linear drag:** straight line.
**Angular drag:** Slowing down in a rotational movement.*

------

**Personal references:**

**Unity**

**Physics material:** [https://docs.unity3d.com/ScriptReference/PhysicsMaterial.html](https://docs.unity3d.com/ScriptReference/PhysicsMaterial.html)

**Physics:** [https://docs.unity3d.com/ScriptReference/Physics.html](https://docs.unity3d.com/ScriptReference/Physics.html)

**Physics scene**: [https://docs.unity3d.com/ScriptReference/PhysicsScene.html](https://docs.unity3d.com/ScriptReference/PhysicsScene.html)

**Rigidbody:** [https://docs.unity3d.com/ScriptReference/Rigidbody.html](https://docs.unity3d.com/ScriptReference/Rigidbody.html)

**Game Object:**  [https://docs.unity3d.com/ScriptReference/GameObject.html](https://docs.unity3d.com/ScriptReference/GameObject.html)

**Mathf (A collection of common math functions)** [https://docs.unity3d.com/ScriptReference/Mathf.html](https://docs.unity3d.com/ScriptReference/Mathf.html)

**Vector2:** [https://docs.unity3d.com/ScriptReference/Vector2.html](https://docs.unity3d.com/ScriptReference/Vector2.html)

**Vector3:**  [https://docs.unity3d.com/ScriptReference/Vector3.html](https://docs.unity3d.com/ScriptReference/Vector3.html)

-----
**Citations**
-----
- *Cite all resources used in planning and development including the basis project, assets, guides, tutorials, and use of generative AI.*


**Shapes:**


https://assetstore.unity.com/packages/3d/props/interior/low-poly-wooden-kid-s-toys-162585

https://assetstore.unity.com/packages/3d/props/3d-collection-of-toys-113302

**Characters:**

[https://assetstore.unity.com/packages/3d/characters/humanoids/humans/kaykit-adventurers-character-pack-for-unity-290679](https://assetstore.unity.com/packages/3d/characters/humanoids/humans/kaykit-adventurers-character-pack-for-unity-290679)

**Map:**

(Not decided yet)

[https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-forests-creation-kit-223495](https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-forests-creation-kit-223495)

[https://assetstore.unity.com/packages/3d/vegetation/lowpoly-forest-lite-291277](https://assetstore.unity.com/packages/3d/vegetation/lowpoly-forest-lite-291277)

[https://assetstore.unity.com/packages/3d/environments/sci-fi/free-demo-of-low-poly-space-alien-worlds-3d-asset-pack-258683](https://assetstore.unity.com/packages/3d/environments/sci-fi/free-demo-of-low-poly-space-alien-worlds-3d-asset-pack-258683)

**Tutorials:**

https://www.youtube.com/watch?v=I1beTn_913c&list=PL9gnJgSxuivEf8D6upAd5aNj6H4OFWt4m

https://www.youtube.com/watch?v=Weu305NLMqo&t=299s

https://www.youtube.com/watch?v=efwckORvGf4&t=2109s

https://www.youtube.com/watch?v=2FTDa14nryI&t=812s

https://www.youtube.com/watch?v=ZPUtQ4pGGWs

https://www.youtube.com/watch?v=mbuH_n5dl38&t=74s

https://www.youtube.com/watch?v=g6RWfR2nUV4&t=262s

https://www.youtube.com/watch?v=HF-cp6yW3Iw&t=14s
