
# API de Gestion des Dépenses

Cette API en .NET 8 / C# permet d'ajouter une dépense, consulter des dépenses avec pagination, consulter une dépense, et supprimer une dépense.

## Sommaire
- [Installation](#installation)
- [Test de l'API](#testapi)
- [Endpoints](#endpoints)

## Installation

### Cloner le dépôt
Cloner le dépôt :  
`https://github.com/akaboubi/GestionDepenses.git`  
Vous pouvez le faire via Git Bash ou directement dans Visual Studio 2022.

Ouvrir la solution `DepensesTechnicalTest.sln` dans Visual Studio.

### Dépendances Entity Framework à installer
- `EntityFramework` — version 9.0.4  
- `Microsoft.EntityFrameworkCore.Design` — version 9.0.4  
- `Microsoft.EntityFrameworkCore.SqlServer` — version 9.0.4

### Base de données & Entity Framework

1. j'ai installé **SQL Server Management Studio (SSMS)**.
2. j'ai installé  **SQL Server Express Edition** :  
   [Télécharger SQL Server](https://www.microsoft.com/fr-fr/sql-server/sql-server-downloads)
3. Se connecter à l’instance `.\SQLEXPRESS` via SSMS.
4. j'ai Crée une base de données vide nommée **DepenseDatabase**.
5. Vérifier la chaîne de connexion dans `appsettings.json`.
6. Exécuter dans le terminal :
   ``` bash
   dotnet ef database update
   ```
7. Vérifier que les tables `[Depenses]` et `[__EFMigrationsHistory]` sont créées.
8. Ajouter quelques valeurs à la table `[Depenses]` via Swagger (POST).

**Remarque :** si la table [Depenses] ne se crée pas dans la base de données, dans ce cas supprimer le dossier "\Migrations" puis regénérer de nouveau la migration initiale "FirstCreateDepenseDB" via cette commande
```bash
dotnet ef migrations add FirstCreateDepenseDB
```

### Démarrer l'API localement

Cliquez sur "Exécuter" dans Visual Studio 2022.  
Swagger s'ouvrira à l'adresse :  
`https://localhost:7275/swagger/index.html`  
Vous y trouverez les 4 endpoints : (2 GET, 1 POST, 1 DELETE)

---

## Test de l'API

Cette API permet :

- Consulter la liste des dépenses (avec pagination)
- Créer une nouvelle dépense
- Consulter une dépense spécifique
- Supprimer une dépense

### Clé `nature` :

- Si `nature == 0` : DEPLACEMENT ⇒ nécessite la clé `distance`
- Si `nature == 1` : RESTAURANT ⇒ nécessite la clé `nombreInvites`

---

## Endpoints

### 1. Consulter une liste de dépenses paginée

**GET** `/api/Depenses?pageNumber=1&pageSize=10`

**Réponse :**
```json
[
  {
    "id": 1,
    "montant": 105,
    "date": "2025-05-02T17:17:44.274",
    "commentaire": "comment1",
    "nature": 1,
    "distance": null,
    "nombreInvites": 2
  },
  {
    "id": 2,
    "montant": 105,
    "date": "2025-05-02T17:17:44.274",
    "commentaire": "comment2",
    "nature": 1,
    "distance": null,
    "nombreInvites": 2
  },
  {
    "id": 6,
    "montant": 548,
    "date": "2025-05-02T17:31:49.882",
    "commentaire": "comment3",
    "nature": 0,
    "distance": 1,
    "nombreInvites": null
  }
]
```

### 2. Récupérer une dépense par ID

**GET** `/api/Depenses/{id}`

**Réponse :**
```json
{
  "id": 1,
  "montant": 105,
  "date": "2025-05-02T17:17:44.274",
  "commentaire": "comment1",
  "nature": 1,
  "distance": null,
  "nombreInvites": 2
}
```

### 3. Ajouter une dépense

**POST** `/api/Depenses`

**Requête :**
```json
{
  "montant": 400,
  "date": "2025-05-04T15:00:09.142Z",
  "commentaire": "comment 4",
  "nature": 0,
  "distance": 200,
  "nombreInvites": null
}
```

**Réponse 200 (Succès) :**
```json
{
  "id": 8,
  "montant": 400,
  "date": "2025-05-04T15:00:09.142Z",
  "commentaire": "comment 4",
  "nature": 0,
  "distance": 200,
  "nombreInvites": null
}
```

### 4. Supprimer une dépense

**DELETE** `/api/Depenses/{id}`

**Réponse 200 (Succès) :**

