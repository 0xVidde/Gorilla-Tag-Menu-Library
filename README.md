
![Logo](https://cdn.discordapp.com/attachments/1084603189053116538/1085228360763965531/New_Project.png)


# Menu Maker 3000

This is a simple but powerful mod menu creation tool for the VR game Gorilla Tag.
## Acknowledgements

 - [Best Youtube Channel On The Earth](https://www.youtube.com/@elvidde9201)
 - [My Discord](https://www.youtube.com/@elvidde9201)

## Authors

- [@0xVidde](https://www.youtube.com/@elvidde9201)


## FAQ

#### Will this be updated?

***Absolutely yes***, I plan on adding support for so much more *than there already is*.

#### Will I get banned for using this?

***No***. This is just a tool for creating a interactable menu in game, not a hacking tool. Though I can't really stop you from doing what you want with it.

## Features

- Create your **own** custom menu is 5 minutes
- Page System
- Button System
- Input System; Handle your *all* controller input with just 1 line of code!
- Object Oriented!
- Built In Documentation!
- Open Source
## Screenshots

![App Screenshot](https://cdn.discordapp.com/attachments/1084603189053116538/1085221161316663436/image.png)


## Usage/Examples

```javascript
MenuTemplate menu = MenuTemplate.CreateMenu(
    "Hello World",     // Title
    new Vector3(0.1f, 1f, 1f),     // Size
    Color.black,            // Color
    GorillaLocomotion.Player.Instance.leftHandTransform.gameObject  // Pivot Point
);
```

