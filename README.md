# BoidsEnvironmentSimulation
***NOTE** This project is not in its final state. This was a project for school and the school did not permit me to upload the final working version of my boids project. This version is bare-bones and most of the natural selection has yet to be implemented, but the boids algorithm, different species, and procedurally generated terrain are fully implemented*
## Description
The project, in its simplicity, is an extension of the boids algorithm to construct a fish-like ecosystem and simulate natural selection and reproduction. 

The boid (bird-oid) algorithm is a common artificial life program that simulates complex flocking behavior in birds and fish (think that tuna scene from Finding Nemo) and runs on three distinct rules:
1. Cohesion: Boids will move towards the average position of the flock
2. Separation: All boids will avoid colliding into other boids and steer away
3. Alignment: Boids of a flock will align themselves in such a way that all boids (ideally) move in the same direction

The combination of these three simple rules can create some advanced behavior, such as in the photos below (taken from my project)
![Alt text](<Boids Image 1.jpg>)

***MORE IMAGES TO COME***


I have extended the boid algorithm to create different species of boids (represented by the different colors shown above) each with different characteristics to differentiate them.
## Characteristics of my Boids
The different characteristics being simulated are:
1. Size
2. Movement Speed
3. Bite Damage - Smaller fish nibble, bigger fish chomp
3. Hunger Meter - how much food the boid can eat
4. Hunger Tick Speed - how often a boid's hunger drops
5. Hunger Threshold - at what % hungry does the boid start searching for food
6. Reproduction Rate - how frequently will the boid reproduce
7. Reproduction Number - Number of offspring (actual offspring is a random number around the variable)
8. Separation Value - Bigger fish (like sharks) do not hunt in groups, they hunt by themselves
9. Cohesion Value - Smaller fish will circle around in a schooling nature more than bigger fish
10. Plant Reproduction Speed, Frequency, and Health Value (amount of bite damage it can withstand before dying)

All boids die when their hunger reaches zero and all plants die when their health reaches zero. Plants to not feed on anything as they photosynthesize. 

##Different Species
#####Herbivores (Green Boids)
These creatures are the most small in size (the screenshot does not represent this as they are closer to the camera), have the fastest hunger, feed on the plants, and are the prey for the red and purple boids.

#####Common Fish (Red and Purple Boids)
These boids are your standard, middle-of-the-pack boids with medium speed, medium hunger, and the highest cohesion value. These boids feed on the herbivores, as well as each other (reds eat purple and vice-versa).

#####Sharks (Blue Boids)
The apex predator in my simulation, the sharks feed on both the common fish and move the slowest, can survive without food for the longest, and rarely travel in schools. Sharks also reproduce the least often, and their only real threat is not finding food fast enough.

##Other Features
In an attempt to add another feature to my ecosystem (get a better grade on my project) I implemented procedurally generated three-dimensional terrain. The boid species originally spawn (colored circles) on different corners of the map and have to navigate their way towards all food. There are a number of variables to change, but it is a pretty standard mesh implementation using perlin noise.
![Alt text](<Boids Terrain Image 1.jpg>)
