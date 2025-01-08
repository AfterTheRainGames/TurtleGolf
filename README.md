# Turtle Golf
**Game Description**  
*OCEAN Theme | Limitation: As Small as Possible | May 24-27 2024*

## Overview  
**Turtle Golf** is a physics-based puzzle game where players control a turtle navigating through puddles by dropping a rock and creating ripples in the water. The goal is to solve puzzles by manipulating the water level by triggering ripples, while carefully controlling the turtle's movements and interactions with different environmental elements like puddles and rocks.

Players must position the turtle in specific puddles, adjust sliders to control the rock’s trajectory, and use the water’s ripple effect to complete various challenges. The dynamic water physics and turtle’s buoyancy mechanics provide a unique twist on a traditional golf game.

---

## Key Contributions as a Gameplay Engineer  

### **Turtle Movement & Water Interaction**  
  - Developed turtle’s buoyancy system based on physics interactions, adjusting the turtle’s vertical position in the water.  
  - Created dynamic water level changes, integrating with turtle movement to provide realistic buoyancy.

### **Ripple System**  
  - Implemented the ripple effect triggered by rocks, adjusting the ripple size and force based on player input.  
  - Ensured that ripple mechanics interact with the environment and affect the gameplay flow.

### **Water Zones & Puddles**  
  - Designed multiple puddles with unique properties, affecting water levels and triggering specific gameplay mechanics when the turtle enters them.  
  - Implemented triggers for entering puddles, adjusting water levels, and enabling ripple spawning.

### **User Interface for Rock Placement**  
  - Added sliders for adjusting the rock's position before it’s dropped into the water.  
  - Created UI elements to interact with the environment and position the rock correctly.

### **Physics-based Collision Handling**  
  - Integrated collision detection for the turtle with ground and water bodies to trigger ripple effects.  
  - Ensured smooth and consistent physics interactions for rocks and the turtle.

---

## Challenges Overcome  

### **Ripple Force Calculation**  
  - **Issue**: Ensuring the ripple force and size were influenced by the rock’s placement and velocity.  
    - **Solution**: Developed a system to calculate ripple force dynamically based on the turtle’s actions and rock drop mechanics.

### **Dynamic Water Interaction**  
  - **Issue**: Ensuring the turtle’s buoyancy was responsive to changes in water level and velocity.  
    - **Solution**: Created a buoyancy system that reacts to the turtle's velocity and the water level, adjusting the vertical position accordingly.

### **Environmental Interactions & Puzzles**  
  - **Issue**: Creating diverse puzzles that require manipulating water levels and ripple effects.  
    - **Solution**: Designed multiple water areas (puddles) with unique challenges, requiring players to think strategically about turtle placement and rock drop.

---

## Reflection  
Turtle Golf combines unique water mechanics with challenging puzzle-solving elements, offering an engaging and physics-based gameplay experience. The dynamic interactions between the turtle, water levels, and ripple effects create a puzzle system that is both intuitive and rewarding.

The integration of ripple effects, buoyancy mechanics, and the user interface elements enhanced the game's puzzle design, providing players with both visual and tactical feedback as they progress through the challenges.

---

## Play the Game  
[Play Turtle Golf on Itch.io](https://aftertheraingames.itch.io/turtle-golf)
