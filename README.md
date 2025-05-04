# Express Voitures - Application de gestion de parc automobile

Express Voitures est une application web développée avec ASP.NET Core qui permet de gérer un parc automobile. Elle offre une interface conviviale pour visualiser, gérer et administrer une collection de véhicules.

## Fonctionnalités

### Fonctionnalités publiques
- Visualisation des véhicules disponibles
- Consultation des détails d'un véhicule (caractéristiques, prix, disponibilité)
- Système d'inscription et de connexion utilisateur
- Interface responsive adaptée aux mobiles et ordinateurs

### Fonctionnalités administrateur
- Gestion complète du parc automobile (CRUD)
- Ajout de nouveaux véhicules
- Modification des informations des véhicules existants
- Suppression des véhicules

## Technologies utilisées

- **Backend**: ASP.NET Core 8.0, Entity Framework Core
- **Frontend**: HTML5, CSS3, Bootstrap 5, JavaScript
- **Base de données**: Microsoft SQL Server
- **Authentification**: ASP.NET Core Identity

## Prérequis

- .NET 8.0 SDK
- Microsoft SQL Server 2019 ou supérieur
- Visual Studio 2022 ou Visual Studio Code

## Installation

1. Clonez le dépôt
   ```
   git clone https://github.com/votre-compte/Projet5.git
   ```

2. Restaurez les packages NuGet
   ```
   dotnet restore
   ```
    Si vous utilisez Visual Studio, ouvrez le projet et restaurez les packages via la console NuGet.
    ```
    Restore-Package
    ```

3. Configurez la chaîne de connexion dans `appsettings.json`
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=VOTRE_SERVEUR;Database=ExpressVoitures;TrustServerCertificate=True;"
   }
   ```

4. Appliquez les migrations pour créer la base de données
   ```
   dotnet ef database update
   ```
   console NuGet.
    ```
    Update-database
    ```

5. Exécutez l'application
   ```
   dotnet run
   ```

## Structure du projet

- **Controllers/** - Contrôleurs de l'application
  - **HomeController.cs** - Gère les pages d'accueil
  - **VoituresController.cs** - Gère les opérations CRUD sur les véhicules

- **Models/** - Classes modèles
  - **VoitureModel.cs** - Modèle pour les véhicules

- **Views/** - Templates Razor
  - **Account/** - Vues liées à l'authentification
  - **Home/** - Pages d'accueil et autres pages générales
  - **Voitures/** - Vues pour la gestion des véhicules
  - **Shared/** - Layouts et vues partagées

- **Services/** - Services personnalisés
  - **UserService.cs** - Gestion des utilisateurs et de leurs rôles

- **Data/** - Contexte de base de données et migrations
  - **ApplicationDbContext.cs** - Contexte EF Core
  - **Migrations/** - Migrations de base de données

## Utilisation

### Utilisateurs standards
1. Accédez à la page d'accueil
2. Naviguez vers "Nos véhicules" pour voir la liste des véhicules disponibles
3. Cliquez sur un véhicule pour en voir les détails

### Administrateurs
1. Connectez-vous avec un compte administrateur
3. Gérez les véhicules (ajout, modification, suppression)
4. Consultez les statistiques du parc automobile

## Configuration des comptes administrateurs

Pour promouvoir un utilisateur au rôle d'administrateur, exécutez la requête SQL suivante dans SSMS :

```sql
DECLARE @userId nvarchar(450) = (SELECT [Id] FROM AspNetUsers WHERE NormalizedEmail = 'exemple@exemple.com'); -- email de l'administrateur
DECLARE @roleId nvarchar(450) = (SELECT [Id] FROM AspNetRoles WHERE NormalizedName = 'ADMIN'); -- Identifiant du rôle

-- Insérer les enregistrements dans AspNetUserRoles pour l'utilisateur exemple@exemple.com
INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES (@userId, @roleId);


```

Remplacez `email@example.com` par l'adresse email de l'utilisateur à promouvoir.


