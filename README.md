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
