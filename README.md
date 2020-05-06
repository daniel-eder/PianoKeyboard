# PianoKeyboard
PianoKeyboard is a simple program that allows to convert MIDI signals from keyboards to text entry. 
Any MIDI keyboard can be used with this program as a computer keyboard alternative. 

PianoKeyboard has been inspired by PianoText by Anna Feit ( http://annafeit.de/pianotext/ ). PianoText has a much greater feature set, 
however our specific use case only required a very simple implementation, that also allowed to translate certain special characters easily.

## Configuration
The translation of notes and octaves to characters can be configured in config.json
This file is currently not automatically generated, so make sure to copy default-config.json to the output directory and rename it to config.json 

The default translation settings are adapted for the person this was created for, so this might not reflect your optimal configuration.

Each settings entry consists of three parts: "Command", "Note" and "Octave". Note and Octave specify the key on the piano keyboard. 
Command can specify either a character, a set of characters, or a command. Commands are notated by starting with "{" and ending with "}".
Currently only {BACKSPACE}, {SPACE} and {RETURN} are implemented. 

## Contributing

Any contribution will be gladly accepted, provided that they are generally useful and follow the conventions of the project.

If you are considering a contribution, please read and follow these guidelines.

### Contribution Guidelines
All contributions should be submitted as pull requests.

1. Please create **one pull request for each feature**. This results in smaller pull requests that are easier to review and validate.

1. **Avoid reformatting existing code** unless you are making other changes to it.
  * Cleaning-up of `using`s is acceptable, if you made other changes to that file.
  * If you believe that some code is badly formatted and needs fixing, isolate that change in a separate pull request.

1. Please **describe the motivation** behind the pull request. Explain what was the problem / requirement. Unless the implementation is self-explanatory, also describe the solution.
  * Of course, there's no need to be too verbose. Usually one or two lines will be enough.


# Changelog

## Version 1.0.0
This is the initial release. 
