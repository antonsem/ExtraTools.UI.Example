# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0] - 2026-11-17

### Added

- UniTask (`com.cysharp.unitask`), required by the ExtraTools.UI package
- Input System (`com.unity.inputsystem`) and controller support: focus on the dialogs' default answers, Cancel routed to the top dialog or active screen through `SampleSceneUIManager`
- "Keep Selection" enabled on the manager, so right or middle clicks and clicks on disabled buttons don't lose focus
- CLAUDE.md

### Changed

- ExtraTools.UI package version updated to 3.4.0
- Screens, panels, dialogs and widgets updated to the package's UniTask based API, with `.Forget()` on fire-and-forget calls
- "No" is the default answer of the quit dialog
- Rider package version updated to 3.1.0
- Unity version updated to 6000.3.27f2
- Unused Unity module dependencies removed

## [1.0.1] - 2024-01-10

### Added

- Changelog

### Changed

- ExtraTools.UI package version updated to 1.2.5
- Rider package version updated to 3.0.34
- Unity version updated to 6000.0.33f1

### Fixed

- Null reference exception due to an unassigned button
