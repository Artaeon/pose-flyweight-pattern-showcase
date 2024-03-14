# Pose-Flyweight-Pattern-Showcase

## Überblick

Dieses Projekt demonstriert die Verwendung des Flyweight-Musters in einer interaktiven Kartenanwendung. Durch die Implementierung dieses Musters erreichen wir eine erhebliche Reduzierung des Speicherverbrauchs, indem wir vermeiden, für jeden Pin auf der Karte eine separate Instanz zu erstellen. Stattdessen wird ein einziges Pin-Objekt wiederverwendet, um verschiedene Pins darzustellen. Das Backend ist in C# entwickelt, während das Frontend in Java umgesetzt ist, um eine breite Kompatibilität und Leistung zu gewährleisten.

## Systemanforderungen

- .NET Core 8.0 für das Backend
- Java JDK 11 für das Frontend
- Java Primefaces als Component Library
- Java JSF -> Java Server Faces
- Eine moderne IDE, die C# und Java unterstützt (z.B. Visual Studio für C# und IntelliJ IDEA für Java)

## Installation

### Backend (C#)

1. Klone das Repository auf deinen lokalen Rechner.
2. Navigiere zum Backend-Verzeichnis des Projekts.
3. Führe `dotnet restore` aus, um alle notwendigen NuGet-Pakete zu installieren.
4. Starte das Backend mit `dotnet run`. (http)

### Frontend (Java)

1. Navigiere zum Frontend-Verzeichnis des Projekts.
2. Öffne das Projekt in deiner bevorzugten IDE, die Java unterstützt.
3. Stelle sicher, dass alle benötigten Abhängigkeiten richtig aufgelöst und geladen werden.
4. trage die korrekte Adresse des Servers unter \resources\META-INF\microprofile-config.properties ein
5. eigenen Google API Key in die config.ini Datei einfügen 
6. eine running configuration festlegen, als noch nicht festgelegt (clean:clean package wildfly:dev)
7. Starte die Anwendung über die IDE.

## Verwendung

Nachdem sowohl das Backend als auch das Frontend gestartet wurden, öffne einen Webbrowser deiner Wahl und navigiere zur angegebenen URL des Frontends. Die Karte wird geladen und zeigt verschiedene Pins, die durch das Flyweight-Muster effizient verwaltet werden.

Interagiere mit der Karte, um zu sehen, wie Pins hinzugefügt, entfernt oder verschoben werden können, ohne dass dabei signifikanter Speicheraufwand entsteht.

## Architektur

### Backend (C#)

Das Backend implementiert Logik zur Verwaltung der Pins und zur Kommunikation mit dem Frontend. Es verwendet das Flyweight-Muster, um den Speicherverbrauch zu minimieren und gleichzeitig eine hohe Performance zu gewährleisten.

### Frontend (Java)

Das Frontend bietet eine interaktive Benutzeroberfläche, um die Karte anzuzeigen und mit ihr zu interagieren. Es kommuniziert mit dem Backend, um Pins abzurufen, hinzuzufügen oder zu ändern.

## Lizenz

Dieses Projekt ist unter der MIT-Lizenz lizenziert. Siehe die LICENSE-Datei für weitere Details.
