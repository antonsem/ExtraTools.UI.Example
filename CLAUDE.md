# CLAUDE.md

## Project overview
Unity project (see `ProjectSettings/ProjectVersion.txt` for the editor version) that demonstrates and manually tests `com.extratools.ui`. Public repo: `antonsem/extraTools.UI.Example`.
This is the consumer side: the package holds the abstract base classes, this project holds the concrete screens, panels, dialogs and widgets, plus the scene that wires them together.
There is no game here. Button handlers mostly log or open other UI, and that is intentional.

## The package
- The source is a separate repo, usually checked out at `../ExtraTools.UI`, with its own `CLAUDE.md`. Read it when a task depends on how the base classes behave. Read the package source rather than guessing.
- `Packages/manifest.json` points to either the GitHub URL or a local `file:` checkout during package development. Don't change which one without asking.
- Fix package bugs in the package, not with workarounds here. If the cause is in the package, tell me and wait before editing that repo. Its rules are different.
- UniTask has to be installed by the consuming project. The package uses it but doesn't declare it in its `package.json`, so `com.cysharp.unitask` must stay in `manifest.json`.

## Project structure
- `Assets/Scripts/`: all code, in one assembly (`Project.asmdef`, root namespace `Project`). It references `ExtraTools.UI`, UniTask and `Unity.TextMeshPro` by GUID.
  - `Managers/`: `SampleSceneUIManager`, shows `_defaultScreen` on `Start`
  - `Screens/`: `MainMenu`, `Settings`, `MultiplePanel`
  - `Panels/`: `AudioSettings`, `VideoSettings` (tabs of `Settings`), `PanelA`-`PanelD` (additive top and bottom panels of `MultiplePanel`)
  - `Dialogs/`: `Generic`, `Fancy`
  - `Widgets/`: `GenericWidget`
- `Assets/Scenes/SampleScene.unity`: the only scene. All UI lives here, there are no prefabs.
- `Assets/TextMesh Pro/`: imported TMP resources. Leave alone.
- `.idea/`, `Library/`, `Temp/`, `Logs/`, `obj/`, `UserSettings/`, `*.csproj`, `*.sln`: IDE or Unity generated. Ignore these.
- `*.meta`: Unity generated. Never hand-edit, create or delete them (see Things to avoid).

Namespaces follow the folders: `Project.Screens.MainMenu`, `Project.Panels.AudioSettings`, `Project.Dialogs.Generic`, `Project.Widgets`, `Project.Managers`.

## Implementation patterns
Every feature is a presenter (`XBase` subclass) plus a view (`XUIBase` subclass), in one folder and one namespace.
- Naming is required by the package's "Set Screen" style inspector buttons: the view must be `<PresenterName>UI` (`MainMenuScreen` → `MainMenuScreenUI`). Presenters end in `Screen`, `Panel`, `Dialog` or `Widget`.
- The view owns the UI references as `[SerializeField] private` fields, subscribes in `OnEnable` and unsubscribes in `OnDisable`.
- Screen, panel and widget views get their presenter by overriding `Initialize` and casting (`_mainMenuScreen = screenBase as MainMenuScreen;`), then call `base.Initialize`. `DialogUIBase` has no `Initialize`: dialog buttons come from `DialogAnswer` callbacks, and clicks are handled by overriding `DialogBase.OnClicked`.
- View click handlers are `private` and only forward to `internal` presenter methods. Logic stays in the presenter.
- Reach other UI through `UIManager.GetScreen<T>()`, `GetDialog<T>()` and `GetWidget<T>()` with the exact concrete type. Look-ups by base class fail.
- Each concrete screen, dialog or widget type can exist only once under the manager, and each panel type only once per screen. Duplicates throw on registration.
- Panels are driven from their own screen (`ShowPanelAsync<T>`, `HidePanelAsync`). Outside callers can only use the public `ScreenBase.Show<T>` / `Hide<T>`. A panel talks to its screen through a reference cast in `Initialize`.
- Empty subclasses (`GenericDialog`, `PanelAPanel`) are fine when the base behaviour is enough. Don't pad them.
- Lifecycle overrides that only log exist to show the call order. Keep them, and always call `base`.

## Async
- The package API is UniTask based, not `Task`. Keep override signatures identical, including the `CancellationToken cancellationToken = default` parameter where the base has it.
- Awaited calls return `UniTask`. Mark fire-and-forget calls from sync handlers with `.Forget()` (`settingsScreen.Show().Forget();`).
- Dialog and widget `Show(...)` are `void`, so there is nothing to forget.

## Coding conventions
- Match the package style:
  - No `var`. Always use explicit types; use target-typed `new()` when the type is already on the left.
  - Private fields are `_camelCase`. Constants are `PascalCase` inside a `#region Constants`, as in the package's `UIManagerBase`. This project has none yet.
  - Indent with tabs.
  - Namespace blocks use braces (not file-scoped).
  - Group members with `#region Unity Methods` and `#region Base` as the existing classes do.
- No `GameObject.Find` or `FindObjectOfType`.
- This project is reference code that people copy. Prefer the clearest use of the package API over cleverness, and show one idea per example.
- Comments explain why, not what.

## Things to avoid
- Don't touch `.meta` files. If a file is added, renamed or moved, tell me and I'll let Unity generate the metadata.
- Don't hand-edit `SampleScene.unity` or anything else in serialized YAML. Tell me what to set up in the editor instead.
- Don't rename a `MonoBehaviour` class, its file or a `[SerializeField]` field without warning me. The scene references scripts through their `.meta` GUID and stores field values by name, so references can break silently.
- Don't modify `Packages/manifest.json`, `packages-lock.json` or `ProjectSettings/` without asking.
- Don't add package dependencies or asmdef references without asking.
- Don't edit anything in `../ExtraTools.UI` without asking.
- Don't rewrite working examples when asked for a small change. Make the smallest change that works.
- Don't try to push or commit changes to git repository.

## Versioning and changelog
- `CHANGELOG.md` uses Keep a Changelog format. Update it only when asked to prepare a release.

## Working style
- When brainstorming a new example, give two or three options with trade-offs before writing code.
- For implementation, start with the smallest testable slice.
- Before large edits, state the plan and which files will change.
- Code alone rarely finishes a feature here. Whenever a change needs scene work, list it explicitly: which `GameObject` gets which component, where it goes under the manager, which fields and buttons to assign, and which setup button to press.
- There are no automated tests. Verification is entering Play Mode in `SampleScene`, so say what to click and what should appear in the UI and Console.

## Debugging
- When investigating a bug, read the related scripts first and state the likely cause before proposing a fix.
- Ask for the Console or Player log if a runtime error is involved.
- Most issues come from setup, not logic. Check these first:
  - unassigned serialized fields (`_defaultScreen`, buttons, `_topPanels`, `_bottomPanels`, `_canvas`, `_screenUI`). The changelog already records one such null reference from an unassigned button
  - a view not named `<Presenter>UI`
  - a duplicated component type under the manager
  - a component placed outside the manager's hierarchy
- A missing-namespace compile error for `Cysharp` or `ExtraTools.UI` points to `manifest.json` or `Project.asmdef`, not the script.
