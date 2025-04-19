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
- Tableau de bord avec statistiques

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

3. Configurez la chaîne de connexion dans `appsettings.json`
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=VOTRE_SERVEUR;Database=ExpressVoitures;User ID=VOTRE_UTILISATEUR;Password=VOTRE_MOT_DE_PASSE;TrustServerCertificate=True;"
   }
   ```

4. Appliquez les migrations pour créer la base de données
   ```
   dotnet ef database update
   ```

5. Exécutez l'application
   ```
   dotnet run
   ```

## Structure du projet

- **Controllers/** - Contrôleurs de l'application
  - **AccountController.cs** - Gère l'authentification
  - **HomeController.cs** - Gère les pages d'accueil
  - **VoituresController.cs** - Gère les opérations CRUD sur les véhicules

- **Models/** - Classes modèles
  - **VoitureModel.cs** - Modèle pour les véhicules
  - **UserModel.cs** - Modèle pour les utilisateurs personnalisés

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
4. Créez un compte ou connectez-vous pour accéder à plus de fonctionnalités

### Administrateurs
1. Connectez-vous avec un compte administrateur
2. Accédez à l'onglet "Administration"
3. Gérez les véhicules (ajout, modification, suppression)
4. Consultez les statistiques du parc automobile

## Configuration des comptes administrateurs

Pour promouvoir un utilisateur au rôle d'administrateur, exécutez la requête SQL suivante dans SSMS :

```sql
UPDATE Users
SET EstAdministateur = 1
WHERE Identifiant = 'email@example.com';
```

Remplacez `email@example.com` par l'adresse email de l'utilisateur à promouvoir.


