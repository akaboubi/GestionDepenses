# l'API de Gestion des Dépenses

Cette API en .Net8/c# permet simplement, d'ajouter une dépense, consulter des dépenses avec pagination, consulter une dépense,et supprimer une dépense.

## Sommaire
- [Installation](#installation)
- [TestApi](#testApi)
- [EndPoints](#endpoints)

## Installation

### Clone de Repo
cloner le repo "https://github.com/akaboubi/GestionDepenses.git" via bash ou avec Visual Studio 2022

Puis dans VS 2022 ouvrir la solution "DepensesTechnicalTest.sln"

### dépendances à installer liées à EntityFramwork
EntityFramwork --version 9.0.4
Microsoft.EntityFrameworkCore.Design --version 9.0.4
microsoft.entityframeworkcore.sqlserver --version 9.0.4

### Base de données/EntityFramwork
-J'ai installé SSMS 2020 pour se connecter au serveur de base de données.

-j'ai installé la version Express de SQL server voici le lien de téléchargement  : https://www.microsoft.com/fr-fr/sql-server/sql-server-downloads

-via SSMS j'ai utilisé l'instance .\SQLEXPRESS dans le nom de serveur pour se connecter, voir la chaine de connexion dans appsettings.json pour plus de détails sur le mode de connexion de l'API

-j'ai crée une base de données vide que j'ai nommé "DepenseDatabase".

-j'ai  exécuteé la commande "dotnet ef database update" en ligne de commande via le terminal de VS 2022 pour créer la base de données à partir de ma dernière migration (voir dossier Migrations pour plus de détails).

-Avant de tester, assurer vous que la commande "dotnet ef database update" est bien passé, puis vérifier que les deux tables[Depenses] et [__EFMigrationsHistory] sont crées.

-Remplir la tables [Depenses] avec quelques valeurs de test avant de commencer l'utilisation, vous pouvez utiliser le Endpoint POST de swagger. 

- Si vous décider de passer vos propres migrations utiliser cette commande "dotnet ef migrations add 'nomdemigration'"


### Démarrer l'API localement
Dans VS 2022 cliquer sur le bouton exécuter, puis attendre que le swagger se charge , URL "https://localhost:7275/swagger/index.html" avec les quatre endpoints (2 GET, 1 POST et 1 DELETE)


## TestApi

Cette API permet de gérer les dépenses :

- Consulter la liste des dépenses qui existent avec pagination
- Créer une nouvelle dépense
- Consulter une dépense existante
- Supprimer une dépense existante


### le clé Nature :
Dans le JSON le clé "nature" désigne la nature de la dépense, et les contrôles sur les deux autres clés "distance" et "nombreInvites"  dépend de ce clé  "nature".

Si Nature == 0 ==> c'est une dépense de nature DEPLACEMENT
Si Nature == 1 ==> c'est une dépense de nature RESTAURANT


## EndPoints

### 1. consulter une liste de dépenses paginé => changer le paramètre pageSize pour tester la pagination.

**GET** `api/Depenses?pageNumber=1&pageSize=10`


**Réponse :**
```[
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
]```

### 2. Récupérer une seule dépense via son id
**GET** `/api/Depenses/id`

**Réponse :**
```{
    "id": 1,
    "montant": 105,
    "date": "2025-05-02T17:17:44.274",
    "commentaire": "comment1",
    "nature": 1,
    "distance": null,
    "nombreInvites": 2
}```


### 3. Ajouter une dépense
**POST** `/api/Depenses`

**Requête :**
```json
{
  "montant":400,
  "date": "2025-05-04T15:00:09.142Z",
  "commentaire": "comment 4",
  "nature": 0,
  "distance": 200,
  "nombreInvites": null
}```

**Réponse 200 Success:**
```json
{
  "id": 8,
  "montant": 400,
  "date": "2025-05-04T15:00:09.142Z",
  "commentaire": "comment 4",
  "nature": 0,
  "distance": 200,
  "nombreInvites": null
}```

### 4. Supprimer une dépense
**DELETE** `/api/depenses/id`

**Réponse 200 Success => Dépénse supprimé :**


