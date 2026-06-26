# Negrell AGS LocForge

Negrell AGS LocForge is an extensively modified continuation of the original AGS Translation Editor, providing improved compatibility, bug fixes, and additional features for working with Adventure Game Studio translation files.

## Acknowledgements

This project is based on the AGS Translation Editor created by Bernd Keilmann (Taktloss).

Development started from the Bitbucket version of the original project:

https://bitbucket.org/Taktloss/ags_translationeditor/

Since then, the codebase has diverged significantly due to extensive refactoring, bug fixes, and new features. As a result, this project is no longer maintained as a direct fork of the original repository.

A later version of the original project is also available on GitHub:

https://github.com/Taktloss/AGS_TranslationEditor

Original work:  
Copyright © 2015 Bernd Keilmann

Modifications and new code:  
Copyright © 2022–2026 Ivan L. Negrell

## Features

- Open and inspect AGS `.TRS` and `.TRA` files in a user-friendly way.
- Edit translations and save them back as `.TRS` files.
- Convert `.TRS` files into `.TRA` files ready to be used in-game.
- View translation progress statistics.
- Read and decode encrypted text strings stored in `.TRA` files.
- Support multiple text encodings when reading and writing translation files.
- Automatically detect the encoding stored in `.TRA` files when available.
- Manually select the encoding to be used when automatic detection is unavailable.

## Pending Features

- Add wrap-around search support.

## Known Issues

_None currently known._

## Changelog

### 3.0.0

- Renamed the application and updated project branding.
- Added a new application icon.
- Performed a major codebase refactor:
  - reorganized the source tree and folder structure;
  - moved code to more appropriate files;
  - renamed classes, methods, variables and members;
  - standardized naming conventions to PascalCase;
  - improved overall code quality and maintainability.
- Redesigned the internal representation of TRS data.
- Reworked the internal representation and parsing of TRA files, improving accuracy and adding support for newer AGS features.
- Implemented a new encoding/decoding system for TRA, TRS and the application itself.
  - added automatic encoding detection for TRA files when available.
  - added user-selectable encoding support.
  - added encoding to TRS files when saved.
- Added TRA string decryption functionality, allowing retrieval of both decoded bytes and plain text.
- Updated licensing information throughout the project.
- Corrected and synchronized the LICENSE file.
- Updated and expanded the project documentation.

### 2.1.2

- Fixed stream position reset when skipping invalid GameInfo matches.
- Corrected game data version detection and dependent parsing.
- Added warning for unsupported newer game data versions.

### 2.1.1

- Fixed TRA creation and Game Information retrieval for old AGS version games (broken in the previous update).
- Added AGS executable files as a supported format for Game Information retrieval and TRA creation.

### 2.1.0

- Added support for newer AGS games.

### 2.0.0

- Renamed several forms, methods and variables.
- Reorganized part of the codebase into dedicated folders.
- Fixed TRA reading and writing methods. Special characters are correctly loaded, displayed and saved.
- Fixed save behaviour that previously overwrote TRA files with TRS content, making them unusable.
- Added "Go to line" and "Search text" features.

## AGS Files

### TRS File Format

A `.TRS` file should look like this example:

```
// TRS file format
// Each entry consists of TWO consecutive lines:
//   1. Original text
//   2. Translation text
// Lines starting with // are comments and ignored by the parser
// Encoding declaration (optional, must appear before entries):
//#Encoding=EncodingName
//
//#Encoding=UTF-8
// Entry 1
Original Text1

// Entry 2
Original Text2
Test translation
// Entry 3
Original Text3
Translated Text3

```
