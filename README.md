# HiveMindMobileGameTemplate

## 📝 Overview
HiveMindMobileGameTemplate provides a robust foundation for mobile game projects, offering streamlined development, modular architecture, and reliable scalability through integrated package support. This template is designed with industry best practices, focusing on clean code architecture, performance optimization, and developer experience.

## 🚀 Getting Started

### 🛠️ Prerequisites
* Unity Editor 6000.0.42f1 or a compatible version.
* Basic understanding of C# and Unity development.

### 📦 Installation
1. Clone the repository.
```bash
  git clone https://github.com/Emre-Emiroglu/HiveMindMobileGameTemplate.git
```
2. Open the project in Unity.
3. Explore the example scenes to understand the architecture.

### 🗂️ Project Structure
* `Assets/Scripts/Runtime`: Contains all runtime code.
* `Assets/Scripts/Editor`: Contains editor tools and utilities.
* `Assets/Scenes`: Contains example scenes demonstrating the template's capabilities.

## ✨ Key Features

### 🏗️ Architecture & Design Patterns
* **Model-View-Controller (MVC) Architecture**: Clean separation of data (Models), presentation (Views), and business logic (Controllers) using [HMModelViewController](https://github.com/Emre-Emiroglu/HMModelViewController).
* **Mediator Pattern**: Views communicate with Models through Mediators, reducing tight coupling.
* **Dependency Injection with VContainer**: Components are wired together using [VContainer](https://github.com/hadashiA/VContainer), providing better testability and reducing tight coupling.
* **Signal-based Communication**: Decoupled components communicate through a robust signal bus system using [HMSignalBus](https://github.com/Emre-Emiroglu/HMSignalBus).
* **Scope-based Organization**: Code is logically separated into well-defined scopes:
  * **CrossSceneScope**: Manages features that persist across scenes (audio, currency, settings).
  * **GameScope**: Handles game-specific logic, UI, and game flow.
  * **MainMenuScope**: Controls main menu functionality and transitions.
  * **BootstrapScope**: Handles application initialization.
  * **ApplicationScope**: Manages application-level services and configurations.

### 🎮 Game Systems
* **Game Flow Management**: Structured game initialization, play, win/lose conditions, and session management.
* **Level System**: Complete level progression tracking and management.
* **Currency System**: Built-in virtual currency management with persistence and UI updates.
* **Tutorial System**: Integrated tutorial support with persistence to track completed tutorials.
* **UI Panel System**: Flexible UI panel system with mediators connecting UI components to business logic.
* **Audio Management**: Comprehensive audio system with configurable music and sound effects, with volume controls.

### 🧰 Development Tools
* **StartupSceneLoader**: Unity Editor tool that automatically loads the first scene in build settings when entering Play Mode.
* **ScriptableObject-based Settings**: Game settings and configurations stored as ScriptableObjects for easy editing.
* **Persistent Data Storage**: Save game progress and settings with [HMPersistentData](https://github.com/Emre-Emiroglu/HMPersistentData).
* **Object Pooling**: Efficient object reuse with [HMPool](https://github.com/Emre-Emiroglu/HMPool) for better performance.
* **Scene Management**: Clean API for loading scenes with proper lifecycle management.
* **Advanced Debugging**: Enhanced debugging capabilities through [HMProDebug](https://github.com/Emre-Emiroglu/HMProDebug).

### ⚡ Performance & Modern Development
* **Async Programming**: Integration with [UniTask](https://github.com/Cysharp/UniTask) for modern async/await patterns.
* **Optimized Animation**: Integration with [PrimeTween](https://github.com/KyryloKuzyk/PrimeTween) for performant animations.
* **Serialized Dictionary Support**: [AYellowpaper-SerializedDictionary](https://github.com/ayellowpaper/SerializedDictionary) for editor-friendly dictionary serialization.

## 🔗 Dependencies

This template uses several powerful packages:
* **[HMHelpers](https://github.com/Emre-Emiroglu/HMHelpers)**: Common utility functions.
* **[HMModelViewController](https://github.com/Emre-Emiroglu/HMModelViewController)**: MVC architecture implementation.
* **[HMPersistentData](https://github.com/Emre-Emiroglu/HMPersistentData)**: Data persistence solution.
* **[HMPool](https://github.com/Emre-Emiroglu/HMPool)**: Object pooling system.
* **[HMProDebug](https://github.com/Emre-Emiroglu/HMProDebug)**: Advanced debugging tools.
* **[HMSignalBus](https://github.com/Emre-Emiroglu/HMSignalBus)**: Signal system for decoupled communication.
* **[HMUtilities](https://github.com/Emre-Emiroglu/HMUtilities)**: General utilities for game development.
* **[VContainer](https://github.com/hadashiA/VContainer)**: Lightweight dependency injection framework.
* **[UniTask](https://github.com/Cysharp/UniTask)**: Efficient async/await implementation for Unity.
* **[PrimeTween](https://github.com/KyryloKuzyk/PrimeTween)**: High-performance tweening library.
* **[AYellowpaper-SerializedDictionary](https://github.com/ayellowpaper/SerializedDictionary)**: Serializable dictionary solution.

## 🔄 Versioning & Updates
The template is continuously improved with new features and optimizations. Check the [release page](https://github.com/Emre-Emiroglu/HiveMindMobileGameTemplate/releases) for the latest updates.

## 📄 License
This project is licensed under the [MIT License](LICENSE.md) see the LICENSE file for details.

## 🙏 Acknowledgments
Special thanks to the developers of VContainer, UniTask, PrimeTween, AYellowpaper-SerializedDictionary, and the Unity community for their invaluable resources and tools.

## 📬 Contact
Emre Emiroglu - [GitHub Profile](https://github.com/Emre-Emiroglu)

Project Link: [https://github.com/Emre-Emiroglu/HiveMindMobileGameTemplate](https://github.com/Emre-Emiroglu/HiveMindMobileGameTemplate)
