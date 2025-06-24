### 🇬🇧 ENG:

# 🧟 Project Zombies in Your Room

**An XR game developed in Unity for Meta Quest 2/3**

**"Project Zombies in Your Room"** is a fast-paced augmented reality (XR) action game where enemies — zombies — appear right inside your physical room. Using passthrough and the MR Utility Kit, the game generates enemies directly in the player's real-world environment.

---

## 🎮 Gameplay

- 🔫 Shoot zombies using two virtual pistols (left and right hand).
- 💀 Headshot = instant kill.
- 🩸 Body hit = two shots required.
- 🧠 Zombies are dynamically spawned based on the player's surroundings.
- 🎯 Each zombie grants +150 points. The game ends when you reach 2400 points.
- 🧾 A HUD interface displays score and controls game start/restart.

---

## 📽️ Gameplay Demo

▶️ [Watch the gameplay demo](https://drive.google.com/file/d/1O08tDdAkF74BuaQVlj9YG2NG-B723rcf/view?usp=sharing)

---

## ⚙️ Technologies Used

- Unity (XR Interaction Toolkit)
- Meta Quest 2 / 3
- MR Utility Kit
- NavMesh AI
- XR UI / HUD system
- C#

---

## 🔧 Game Systems

### 🔸 Weapon System
- Laser aiming line
- Reloading mechanic with a visual slider
- Shooting sound effects, muzzle flash, and controller haptics
- Ammo management with live UI updates

### 🧟‍♂️ Enemy (Zombie) System
- Zombies track the player and approach them
- Supports both headshot and body hit detection
- Damage logic, animations, and delayed death effects
- Points awarded and zombies removed on death

### 🧬 Zombie Spawner
- Dynamically spawns zombies on vertical surfaces in the real environment
- Uses MR Utility Kit to find wall-like surfaces
- Enforces a limit on active zombie instances

### 🖥️ HUD / UI System
- Start the game by touching an interactive object
- Real-time score and gameplay status display
- End screen with restart functionality
- HUD dynamically positioned in front of the player

---

## 👨‍💻 Authors

- **Konrad Kuleta** (272293)  
- **Mikołaj Lipiński** (273024)

Created as part of the course:  
**“Game Design and Programming”**  
Supervisor: _Dr. Eng. Arch. Tomasz Zamojski_

---

## 📌 Potential Improvements (TODO)

- [ ] Optimize performance with many zombies on screen
- [ ] Add dynamic difficulty scaling system
- [ ] Improve animations and visual hit feedback
- [ ] Introduce an endless survival mode
- [ ] Better handling of small physical spaces

---

### 🇵🇱 PL:

# 🧟 Project Zombies in Your Room

> **Gra XR stworzona w Unity na platformę Meta Quest 2/3**

„Project Zombies in Your Room” to dynamiczna gra akcji w rozszerzonej rzeczywistości (XR), w której przeciwnicy – zombie – pojawiają się w Twoim własnym pokoju. Gra wykorzystuje passthrough i system MR Utility Kit do generowania przeciwników bezpośrednio w otoczeniu gracza.

---

## 🎮 Gameplay

- 🔫 Strzelaj do zombie za pomocą dwóch wirtualnych pistoletów (lewa i prawa ręka).
- 💀 Trafienie w głowę = natychmiastowa eliminacja.
- 🩸 Trafienie w ciało = potrzeba dwóch trafień.
- 🧠 Zombie są generowane dynamicznie na podstawie otoczenia gracza.
- 🎯 Każdy zombie = +150 punktów. Gra kończy się po zdobyciu 2400 punktów.
- 🧾 Interfejs HUD zlicza punkty i pozwala rozpocząć/zrestartować rozgrywkę.

---

## 📽️ Demo wideo

▶️ [Zobacz wideo z gry](https://drive.google.com/file/d/1O08tDdAkF74BuaQVlj9YG2NG-B723rcf/view?usp=sharing)

---

## ⚙️ Technologie

- Unity (XR Interaction Toolkit)
- Meta Quest 2
- MR Utility Kit
- NavMesh
- XR UI (interfejs HUD)
- C#

---

## 🔧 Systemy gry

### 🔸 System broni
- Laserowy celownik
- Przeładowanie z suwakiem
- Efekty dźwiękowe, animacje i wibracje kontrolera
- System amunicji z aktualizacją UI

### 🧟‍♂️ System przeciwników – Zombie
- Zombie porusza się do gracza
- Obsługa headshotów i trafień w ciało
- Logika obrażeń, śmierci i animacji
- Opóźnione znikanie i przekazywanie punktów

### 🧬 ZombieSpawner
- Generuje zombie losowo na pionowych powierzchniach w otoczeniu gracza
- Używa MR Utility Kit do znajdowania ścian
- Ograniczenie maksymalnej liczby aktywnych zombie

### 🖥️ System UI (HUD)
- Start gry przez dotknięcie interaktywnego obiektu
- Punkty i status gry w czasie rzeczywistym
- Ekran końcowy z opcją restartu
- Dynamiczne pozycjonowanie HUD przed graczem

## 👨‍💻 Autorzy

- **Konrad Kuleta** (272293)  
- **Mikołaj Lipiński** (273024)

Praca zrealizowana w ramach kursu  
**„Projektowanie i programowanie gier”**  
Prowadzący: _dr inż. arch. Tomasz Zamojski_

## 📌 Możliwe usprawnienia (TODO)

- [ ] Optymalizacja działania przy większej liczbie zombie
- [ ] Dodanie systemu rozwoju poziomów trudności
- [ ] Rozbudowa animacji i efektów trafień
- [ ] Tryb survival bez limitu punktów
- [ ] Ulepszona obsługa małych przestrzeni fizycznych

---
