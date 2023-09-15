# Simple-Dialogue-System
Simple Dialogue System created by using Unity with scriptable object.
Introduction
This Simple Dialogue System is a simple implementation for creating interactive dialogues within a Unity game. It allows game developers to easily set up conversations between the player character and non-player characters (NPCs) using a provided set of scripts and scriptable objects. I used the simple way to do this system by using scriptable objects instead of dialogue graph.
 
1. Setup
Before using the Dialogue System, you must set up the following:
•	Unity Project: Make sure you have a Unity project ready and open.
•	DialogueManager: Ensure that you have the DialogueManager script attached to a GameObject in your scene. This script manages the dialogues and controls their display.
•	DialogueTrigger: Attach the DialogueTrigger script to the NPC GameObjects that you want to initiate conversations with. This script links to a DialogueScriptable asset that defines the dialogue.
•	UI Elements: Create UI elements in your scene to display the dialogue text and responses. These elements should include a Text Mesh Pro (TMP) Text component for the dialogue text, another for the NPC's name, and a Button for advancing the dialogue. A responseBox that has “Vertical Layout Group” to be the parent of response button prefab.
•	NPC: A gameObject that has tag of “NPC” and rigidbody.
 
2. Scripts and Components
Here are the key scripts and components used in the Dialogue System:
DialogueManager:
•	This script manages the dialogue flow.
•	Contains references to the dialogue text, NPC name, dialogue box, response box, and next button.
•	Provides methods for opening and displaying dialogues, progressing through dialogues, and handling responses.
DialogueTrigger:
•	Attach this script to NPC GameObjects.
•	Links to a DialogueScriptable asset to start conversations.
•	Provides a method to start the dialogue when triggered by the player's interaction.
DialogueScriptable:
•	A ScriptableObject is used to define dialogues and responses.
•	Contains arrays for dialogues, actors, responses, and a boolean to determine if choices are presented to the player.
Dialogue:
•	A data structure defining a single line of dialogue.
•	Contains an actor ID and the text to be spoken.
Actor:
•	A data structure defining an actor's name.
Response:
•	A data structure defining a response option.
•	Contains a prefab for the response button and a reference to the next dialogue to trigger when selected.
ResponseButton:
•	Attached to response buttons in the UI.
•	Handles the click event to trigger the next dialogue in the conversation by its id.
 
3. Usage 
To use the Dialogue System in your game, follow these steps:
1.	Create a DialogueScriptable Asset: Right-click in the Project panel, go to Create > Dialogue > DialogueObject. Configure your dialogues, actors, and responses within this asset.
2.	Set Up UI Elements: Create or assign UI elements for displaying dialogue text, NPC names, and response box (to be the parent of the response button). Attach these elements to the DialogueManager script.
3.	Attach DialogueTrigger: Attach the DialogueTrigger script to the NPCs in your scene that you want to trigger conversations with and set the NPCs with “NPC” tag.
4.	Start Conversations: Implement a system in your game to trigger dialogue activation, such as player proximity, interacting with NPCs, or other in-game events. Use the DialogueTrigger component's StartDialogue method to begin the conversation.
5.	Define Dialogues and Responses: Populate the DialogueScriptable asset with dialogues and responses that suit your game's narrative.
6.	Create response button prefab: Create button gameObject prefab with attach “ResponseButton” script and assign id for it. for example, 0 linked to the first next conversation, 1 linked to the second next conversation. Make it into prefab and assigned into the DialogueScriptable asset. 

4. Creating Dialogues
To create dialogues, follow these steps:
1.	Create a new DialogueScriptable asset by right-clicking in the Project panel and selecting Create > Dialogue > DialogueObject.
2.	In the asset, populate the dialogues array with dialogue lines. Each dialogue should include an actor ID and the text to be spoken.
3.	Define actors in the actors array, including their names.
4.	If the dialogue should present choices, set the choices boolean to true.
5.	If choices are enabled, create response options in the responses array. Each response should include a prefab for the response button and a reference to the next dialogue to trigger when selected.
 
5. Creating Responses
To create response options, follow these steps:
1.	In the DialogueScriptable asset, set the choices boolean to true.
2.	In the responses array, create response options. Each response should include:
•	A prefab for the response button.
•	A reference to the next DialogueScriptable asset to trigger when selected.
3.	Attach the ResponseButton script to the response buttons in your UI. The script handles the button click event and triggers the next dialogue.
 
6. Dialogue Activation
To activate dialogues within your game, implement a system such as:
•	Proximity Trigger: Attach a Collider to NPCs and use OnTriggerEnter to detect the player's proximity. When the player enters the trigger area, use the DialogueTrigger component to start the dialogue.
•	Interaction System: Implement an interaction system where the player can interact with NPCs through button presses. When the interaction occurs, use the DialogueTrigger component to start the dialogue.
•	Event-Based Triggers: Use game events or custom triggers to initiate conversations with NPCs. When the event occurs, call the StartDialogue method on the appropriate DialogueTrigger.
•	Limitation of movement: Limit the movement of player while during the conversation if needed.
 
Conclusion
The Dialogue System provides a straightforward way to create interactive dialogues in your Unity game. By using the provided scripts and scriptable objects, you can easily define conversations, responses, and the flow of dialogues within your game's narrative. Customization and integration into your game's mechanics will help create engaging and immersive dialogues for players to enjoy.
