# DGD2003\_batuhanyazar



**GAME DESIGN DOCUMENT: The Orientation Breach**

**Version: 1.1**



**Genre: First-Person Exploration / 2D Retro Hacking Mini-game**



**Platform: PC (Unity 6)**



**Theme: Orientation, Cybersecurity \& Time Pressure**



**1. EXECUTIVE SUMMARY**

**The player takes on the role of a freshman student at Istanbul Kültür University on their first day. Suddenly, a campus-wide digital lockdown occurs. To navigate through the corridors and reach the "PC Lab" for the final orientation step, the player must interact with locked door terminals and clear "digital viruses" via a retro-style hacking interface (Space Invaders).**



**2. CORE GAMEPLAY MECHANICS**

**2.1. Dual-Layer Interaction**



**3D Exploration Mode: Standard first-person navigation within the university corridors modeled via ProBuilder. The player searches for environmental clues, such as sticky notes or posters containing access codes.**



**2D Hacking Mode: Upon interacting with a locked door, a UI-based mini-game is triggered. The player must defeat waves of "viruses" to override the lock.**



**2.2. The Viral Invaders (Mini-game)**



**Classic Mechanics: A reconstructed 2D Space Invaders engine. The player controls a security program moving horizontally to shoot down incoming virus entities.**



**Win Condition: Clearing all enemies within the sub-timer unlocks the physical door in the 3D world.**



**2.3. Global Time Pressure**



**The Master Timer: A visible countdown on the HUD. The player must reach the final destination before the system fully resets. This adds a layer of urgency, forcing the player to balance careful exploration with fast-paced combat.**



**2.4. Knowledge Gate (The Access Code)**



**The final door to the PC Lab is protected by a 4-digit PIN. Unlike other doors, this requires "Human Intelligence"—the player must find the code hidden somewhere in the 3D environment (e.g., on a bulletin board or a desk).**



**3. WORLD DESIGN**

**Environment: A high-fidelity 3D recreation of the IKU corridors.**



**Visual Contrast: \* The Real World: Clean, academic environment using standard URP materials.**



**The Hacking Interface: A stylized, neon-green CRT aesthetic (Cyberpunk/Retro) to differentiate the digital layer from the physical one.**



**4. TECHNICAL SPECIFICATIONS**

**Player Controller: First-Person Character Controller for 3D movement; discrete 2D input mapping for hacking sequences.**



**UI Integration: The mini-game operates on a World-Space or Screen-Space Overlay Canvas to ensure a seamless transition without switching scenes.**



**Logic: C# scripts managing the "OnTriggerEnter" events for doors and "OnEnemyDestroyed" events for the hacking win-state.**



**5. ART \& AUDIO**

**Visuals: ProBuilder geometry for structural layout; Pixel Art sprites for the hacking mini-game.**



**Audio: Ambient campus sounds (chatter, footsteps) in 3D mode; 8-bit chiptune sound effects during the hacking sequences to enhance the retro feel.**

