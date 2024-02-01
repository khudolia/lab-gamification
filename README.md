# Laboratory Across Borders gamification project
This project was made in purposes of using it for basic block schemes in a gama-manner.
![](https://github.com/khudolia/lab-gamification/assets/79538644/51a04caa-4ab7-4b9e-8fab-efb1d7a0e2a7)

# Documentation
URP is used for the project. It gives cool visual effects for cheap perfomance price. Very convenient to use on different platforms(Web, Mobile, PC)

The general file is shown on the image below. Each folder represents exact purpose of the files inside.
![](https://github.com/khudolia/lab-gamification/assets/79538644/dd2d010d-c233-476a-ba84-2b00002d6ea2)

## How to setup a new level?
For programming canvas just drag n drop "ProgrammingCanvas" from Prefab's folder.
![](https://github.com/khudolia/lab-gamification/assets/79538644/0b480494-95f5-4c48-a049-bf0bf36fa800)
And for all additional buttons: "LevelCanvasOverlay"
![](https://github.com/khudolia/lab-gamification/assets/79538644/8817cd8f-ba63-4246-a1eb-3b42ddce168d)

Then, using scipts related to node programming, you can setup your own level: Animations, UI elements and so on.

## Levels
We have 2 main scenes at the moment:
### Menu
Credits are required for some assets because of their Policy
![](https://github.com/khudolia/lab-gamification/assets/79538644/7dbd666b-a667-4ed8-818a-fd0745310188)

### TrafficLight level
![](https://github.com/khudolia/lab-gamification/assets/79538644/e1736d50-a90e-4dfe-8db1-79b0b9ee38c7)

In Prefabs is everything that needed to be used in the project
![](https://github.com/khudolia/lab-gamification/assets/79538644/765f5c05-9a7e-49bc-9660-230da435e928)

## Scripts
![](https://github.com/khudolia/lab-gamification/assets/79538644/8ec2a347-3485-41be-b836-be2a9da890b1)

### UI
In this folder you can find some scripts which are used for UI. For example, ScaleOnMouseHover is used for scaling buttons out when mouse is pointed at them.
![](https://github.com/khudolia/lab-gamification/assets/79538644/4c44c7e7-2b45-431b-90e6-2584f6df266a)

### Error Controller
When block's connections encounter an error - it should be displayed to show player what's going on
![](https://github.com/khudolia/lab-gamification/assets/79538644/b3dec534-cb10-4af8-b444-c11c550a546c)

It is very easy to use: one script - ErrorController.
Enable, Disable - it's clear;
If it's needed to show some errors, just call ShowErrors function.
![](https://github.com/khudolia/lab-gamification/assets/79538644/b310d400-f5e8-4bb3-89de-e40c66c0467d)

### Block Sequence Controller
This script controlls the level itself. After player is pressing "start" "restart" button.
![](https://github.com/khudolia/lab-gamification/assets/79538644/77d92538-6925-4272-bf13-57d8491aba6f)

### ProgrammingNodeCollector
Collects all connections and is making commands for traffic light to follow to.
CreateSequence - creates a sequence of commands. If it has any errors - it returnes it, then error UI can be called.
RunCode - if sequence was created without any errors - it's free to call RunCode function.
![](https://github.com/khudolia/lab-gamification/assets/79538644/d4f6ef34-5d59-4384-a7c0-16febfb9490f)

### ProgrammingNodeController
A structure-like script for Node object. Contatins all required parameters.
![](https://github.com/khudolia/lab-gamification/assets/79538644/58c9d71e-a7ac-4f5f-b29c-b217419e1d57)

### TrafficLightController
A script which controls the state of TrafficLight. Just Call TurnOnTrafficLight with a desired state to change a state of traffic light.
![](https://github.com/khudolia/lab-gamification/assets/79538644/c9f02895-c148-4364-b2f7-579c4b65359c)


### Graph folder
The basic connection algorithm was taken from UIGraph package, which was free on the Asset Store.
![](https://github.com/khudolia/lab-gamification/assets/79538644/ad2e71a9-7561-4d9a-a986-08cee0d580e1)
Here you can find everything from the package. It is here because a lot of files were modified to match desired result.
Feel free to explore the source code if you want.


### Main menu Controller
Menu controller is for changing game's UI state
![](https://github.com/khudolia/lab-gamification/assets/79538644/8af5726d-9141-4b0e-8774-394e93b93dc8)

To load some levels LevelsLoader is created. Just call/add a required function wherever you need to.
![](https://github.com/khudolia/lab-gamification/assets/79538644/aba5dfd6-fdc6-484d-b93c-d1b8c83162d6)



