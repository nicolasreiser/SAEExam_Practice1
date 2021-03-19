# **Final Exam Practice 1**

# **Skyrim Inventory System**

**Available time:** 3 hours

**Goal:**

Starting from _ **this repository** _, complete all the tasks described below.

**Submission format:**

We will spend the final hour discussing different implementations and problems. If you want additional feedback, fork the repository and share the link.

**Notes:**

You are expected to work with Git by committing into the starting repository. Work in your own branch and merge into main when you are finished. (You are not expected (or allowed) to push.) Git usage will affect the grade in the final exam.

You are allowed to freely use external resources (Internet, books). But **communicating** during the exam with other people (notably the other students taking the exam) **is not allowed** and can be considered cheating.

For the practice, I highly recommended trying to solve everything on your own. Even if the 3 hours of allocated time are not enough, consider trying to solve the problems afterwards.

You are allowed to ask questions during the exam. The examiner will function as a makeshift designer and will answer design questions. Technical questions will not be answered.

Make yourself familiar with the project and codebase before writing your own code. You are expected to follow established guidelines and to reuse existing features when possible.

**Tasks:**

There are 9 Tasks in Total for a collective 100 Points

Task 1: (10 Points)

The player should be able to pick up an item on the ground by pressing &quot;e&quot; (and A/X on a controller) when he is looking directly at it (raycast). Picking up something causes the item to get destroyed.

Task 2: (10 Points)

When the player picks up something, the &quot;Pickup&quot; animation should play, and input/movement should be halted until the player finishes the animation.

Task 3: (10 Points)

Every item should have a set of properties to be used by later systems. Because these properties are to be set and balanced by the design team, use ScriptableObjects and give every Item a dedicated scriptable object instance. The properties to implement are the following: ItemName, Weight, Value, Description, Category.

Task 4: (5 Points)

When looking at an object, the ItemName should be displayed in the middle of the screen in combination with a message to hint a pickup. Example: &quot;Rock (E to Pickup)&quot;

Task 5: (10 Points)

Implement an Inventory class, which can be used to store the items collected via pickup. This class should NOT not inherit from monobehaviour, instead an instance of it should be used by the responsible behaviour. Add an &quot;InventoryChanged&quot; event to the Inventory to be later used to refresh the UI only when necessary.

Task6: (5 Points)

Add a maximum weight variable to the Inventory. If the sum of the Weight of the items carried by the inventory is higher than the maximum weight, the player should become unable to sprint and unable to pick up new items.

Task 7: (10 Points)

Add following Edit Mode Unit Tests to test the inventory system:

- An inventory does in fact correctly calculate it&#39;s max weight
- Negative weight is considered 0 weight
- An inventory with 0 items does not through exceptions when calculating its weight
- An inventory with 0 or less than 0 as it&#39;s Max Weight can carry an Infinite amount

Task 8: (30 Points)

Implement a user interface for the inventory system. On the left side a scrollable list should contain all the items currently present in the inventory. On the right side the currently selected item&#39;s information (From Task 3) should be displayed.

The player should be able to open and close the inventory with the press of the &quot;Tab&quot; (Start/Options on controller) button. While the inventory is opened the game should be paused.

Try to match the structure of the user interface from skyrim as much as possible.

(Note: Ignore the categories, model preview, and bottom bar for now)

(Remider: The aesthetics do not matter, use empty Images and the default font.

BUT resizing errors as well as text overflow errors do matter).

Summary:

1. Inventory UI can be opened and closed
2. The inventory content is displayed in a vertical list which is updates with the content
3. A selected item is displayed on the side which its properties
4. The inventory UI updates correctly when items from the ground are picked up
5. The inventory and inventory UI are separate concepts, the UI reflects the content of the inventory object

(Image 1: Skyrim Inventory) ![](RackMultipart20210319-4-d5xpni_html_2439dca2e6ea24f9.jpg)

Task 9: (10 Points)

Expand the UI to include the categories section. When selecting a specific category, only the items belonging to that category should be present in the list. A default &quot;ALL&quot; category should exist which simply visualizes all items. Add the &quot;CarryWeight&quot; ui element, which displays the current weight compared to the maximum weight (See image)

Bonus Tasks:

(For the ones who finished early or want to keep practicing)

- Expand the UI to include a 3d model preview visualization that can be rotated
- Expand the UI to allow the Player to drop Items out of the inventory and back into their 3D representation
- Expand the UI by adding a &quot;MaxStack&quot; property to items and by stacking Items in the inventory up up to this &quot;MaxStack&quot; amount