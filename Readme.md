# ASP.NET MVC Workshop
<img src="Images/grossweber.png" align="right">

Ihr Trainer: [Johannes Hoppe](http://www.haushoppe-its.de) von [GROSSWEBER](http://grossweber.com/)



# Priorisierte Themenwünsche

Folgende Themen haben Sie mit einer hohen Priorität bewertet. In der nachfolgende Agenda sind die Themen entsprechend berücksichtigt worden. Laut Vorabgespräch sollen aufgrund konkreter Projektanforderungen vor allem serverseitige Technologien im Fokus stehen. Wir empfehlen zusätzlich die Besprechung von Client-seitigen Technologien. Es bietet sich ein Anschluss-Workshop zum Themen-Komplex **JavaScript** an!  

## Grundlagen
- Das Model-View-Controller-Prinzip
- Abgrenzung zu ASP.NET Web Forms-basierten Webanwendungen
- Zustandslose Softwareentwicklung
- Actions
- Views
- Dependency Injection
- Serverseitige Validierung
- Best Practices

## Weiterführend
- ActionFilter
- ActionResult
- Inversion of Control nutzen
- Ajax und MVC
- Client Validierung
- Editor- und Display Templates

## Erweiterbarkeit
- Dependency Injection in ActionFilter und ActionResult
- Asynchrone Controller Actions
- OWIN (Katana)
- Entity Framework 6



<hr>

<div style="page-break-after: always;"></div>

# Agenda


[# Tag 1 - ASP.NET MVC / Web API & C# Unit Testing](Tag_1.md)

1. Themenwahl für Prototyp, Anlegen Projekt
2. Anlegen von DTOs / POCOs (Geschäftsobjekte)
3. Verwendung von IoC & Dependency Injection
4. Einrichten vom Entity Framework, Code First
    1. Besprechung: Mockbarer Context (DbContext) - 3 Ansätze!
5. Refactoring: Verwendung des Repository-Patterns
6. Erstellen eines MVC Controllers
7. Erstellen eines Web API Controllers

Eingesetzte Technologien:
- Nuget
- ASP.NET MVC
- ASP.NET Web API
- Entity Framework 6
- Autofac
- MSpec & Moq & Fluent Assertions


[## Tag 2 - ASP.NET MVC & Kendo UI](Tag_2.md)

1. Besprechung Ergebnisse des Vortags
2. Grundlagen ASP.NET MVC
    * Routing und Bundling
    * Sections
    * Partial Views 
3. Formulare mit ASP.NET MVC
4. ActionFilter
5. Kurz angerissen: OData (IQueryable)
    * OData-Daten anzeigen per Grid und Chart
6. Best Practices (z.B. T4MVC)

Eingesetzte Technologien:
- Nuget
- ASP.NET MVC
- ASP.NET Web API / OData
- Kendo UI (für Grid und Chart)
- T4MVC

## Vorschlag: Tag 3 - JavaScript Grundlagen

- Best Practices / Häufige Fehler
- Prinzipien für Modularer Code
- Vermeidung von Abhängigkeiten
- Daten holen per Ajax (jQuery)
- Require.js


## Vorschlag: Tag 4 - JavaScript Frameworks
1. AngularJS (ODER Knockout.js)
2. Einbindung von Third-Party Komponenten (z.B. Kendo UI)
2. SignalR
4. JavaScript Unit-Tests (Behaviour Driven Tests)


Technologien: AngularJS, SignalR, node.js /npm, Karma Testrunner, Jasmine



## Notwendige Ausstattung

* Eigener Laptop                              
* Visual Studio 2013
* SQL Server 2012 (Express)
* Resharper (ggf. Trial)
* Optional: GitExtensions https://code.google.com/p/gitextensions/ oder Github für Windows


## Online

https://github.com/JohannesHoppe/AspNetMvcWorkshop2015_2