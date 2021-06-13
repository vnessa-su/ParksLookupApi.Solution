# Parks Lookup API

#### API for a MySQL database of parks and park categories.

#### By Vanessa Su

---

## Table of Contents

- [Description](#description)
- [Technologies Used](#technologies-used)
- [Setup/Installation Requirements](#setup/installation-requirements)
- [Installation](#installation)
  - [Database Setup](#database-setup)
  - [Run the API Server](#run-the-api-server)
- [API Documentation](#api-documentation)
  - [View Swagger Documentation](#view-swagger-documentation)
  - [Parks](#parks)
  - [Categories](#categories)
- [Known Bugs](#known-bugs)
- [Contact Information](#contact-information)
- [License](#license)

---

## Description

RESTful API in C# enables access to a MySQL database of parks and park categories. Allows getting all entries for, retrieving particular entries by id, editing entries, and deleting entries for both parks and categories. Parks routes also allow for editing or removing a category association, and selecting a park at random. Park entries have their address geocoded on creation to determine latitude and longitude information in the entry, as well as reformat the state property to a state abbreviation if needed.

## Technologies Used

- C#
- ASP.NET&#8203; Core
- Entity Framework Core
- MySQL
- Swagger
- VS Code

---

## Setup/Installation Requirements

### Prerequisites

- [MySQL](https://www.mysql.com/)
- [.NET](https://dotnet.microsoft.com/)
- A text editor like [VS Code](https://code.visualstudio.com/)
- [MapQuest](https://developer.mapquest.com/) API Key

### Obtain API Key

1. Go to the [MapQuest Developer](https://developer.mapquest.com/) website
2. Click on the `Get your Free API Key` button
3. Fill out the form and click the `Sign Me Up` button
4. Log into your account
5. Click the `Manage Keys` option on the left side
6. Click on the `My Application` dropdown
7. Your API key is the `Consumer Key` under `My Application's Keys`

### Installation

1. Clone the repository: `git clone https://github.com/vnessa-su/ParksLookupApi.Solution.git`
2. Navigate to the `/ParksLookupApi.Solution` directory
3. Open with your preferred text editor to view the code base

#### **Database Setup**

1. Navigate to the `/ParksLookupApi` directory
2. Create appsettings.json file: `touch appsettings.json`
3. Open appsettings.json in a text editor and add in:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=<port number>;database=parks_lookup_api;uid=root;pwd=<password>;"
  },
  "GEOCODE_API_KEY": "<your api key>"
}
```

- Replace `<port number>` with the port number the server is running on, default is usually 3306
- Replace `<password>` with your MySQL password
- Replace `<your api key>` with your MapQuest API Consumer Key

4. Save the file and go back to the terminal
5. Run `dotnet ef database update`

#### **Run the API Server**

1. Navigate to the `/ParksLookupApi` directory
2. Run `dotnet restore`
3. Run `dotnet build`
4. Start the server with `dotnet run`

---

## API Documentation

### View Swagger Documentation

_View API endpoint and database information in your browser. Make test requests with the_ `Try it out` _button in each endpoint's drop-down_

1. Start the server with `dotnet run`
2. Open http://localhost:5000/index.html in your preferred browser

---

### **Parks**

Information on various local, state, and national parks

---

### GET /parks

_Retrieve a list of all parks_

- Example Request

```
http://localhost:5000/parks
```

- Example Response

```
[
  {
    "parkId": 1,
    "name": "Yosemite National Park",
    "address": "9035 Village Drive",
    "city": "Yosemite Valley",
    "state": "CA",
    "latitude": 37.748100000000000000000000000,
    "longitude": -119.58504300000000000000000000,
    "categoryId": 1
  },
  {
    "parkId": 2,
    "name": "Boston Harbor Islands",
    "address": "191W Atlantic Ave",
    "city": "Boston",
    "state": "MA",
    "latitude": 42.360100000000000000000000000,
    "longitude": -71.052016000000000000000000000,
    "categoryId": 3
  },
  {
    "parkId": 3,
    "name": "White Mountain National Forest",
    "address": "71 White Mountain Drive",
    "city": "Campton",
    "state": "NH",
    "latitude": 43.813494000000000000000000000,
    "longitude": -71.670031000000000000000000000,
    "categoryId": 2
  }
]
```

### POST /parks

_Add a park to the database_

- Request Body

```
{
  "name":	string
  "address": string
  "city":	string
  "state":	string
}
```

- Example Request

```
http://localhost:5000/parks
```

- Example Body

```
{
    "name":"Boston Harbor Islands",
    "address":"191W Atlantic Ave",
    "city":"Boston",
    "state":"Massachusetts"
}
```

- Example Response

```
{
  "parkId": 2,
  "name": "Boston Harbor Islands",
  "address": "191W Atlantic Ave",
  "city": "Boston",
  "state": "MA",
  "latitude": 42.3601,
  "longitude": -71.052016,
  "categoryId": 0
}
```

### GET /parks/{id}

_Retrieve park entry by id_

- Example Request

```
http://localhost:5000/parks/3
```

- Example Response

```
{
  "parkId": 3,
  "name": "White Mountain National Forest",
  "address": "71 White Mountain Drive",
  "city": "Campton",
  "state": "NH",
  "latitude": 43.813494000000000000000000000,
  "longitude": -71.670031000000000000000000000,
  "categoryId": 2
}
```

### PUT /parks/{id}

_Update a park database entry_

- Request Body

```
{
  "parkId": integer
  "name":	string
  "address": string
  "city":	string
  "state": string
  "categoryId": integer
}
```

- Example Request

```
http://localhost:5000/parks/2
```

- Example Body

```
{
  "parkId": 2,
  "name": "Boston Harbor Islands National Recreation Area",
  "address": "191W Atlantic Ave",
  "city": "Boston",
  "state": "MA",
  "categoryId": 3
}
```

- Example Response

```
{
  "parkId": 2,
  "name": "Boston Harbor Islands National Recreation Area",
  "address": "191W Atlantic Ave",
  "city": "Boston",
  "state": "MA",
  "latitude": 42.3601,
  "longitude": -71.052016,
  "categoryId": 3
}
```

### DELETE /parks/{id}

_Delete park entry_

- Example Request

```
http://localhost:5000/parks/1
```

### PUT /parks/{id}/category/{categoryId}

_Update park entry with associated category ID_

- Example Request

```
http://localhost:5000/parks/3/category/2
```

- Example Response

```
{
  "parkId": 3,
  "name": "White Mountain National Forest",
  "address": "71 White Mountain Drive",
  "city": "Campton",
  "state": "NH",
  "latitude": 43.813494000000000000000000000,
  "longitude": -71.670031000000000000000000000,
  "categoryId": 2
}
```

### DELETE /parks/{id}/category

_Remove associated category by setting category ID to 0_

- Example Request

```
http://localhost:5000/parks/3/category
```

- Example Response

```
{
  "parkId": 3,
  "name": "White Mountain National Forest",
  "address": "71 White Mountain Drive",
  "city": "Campton",
  "state": "NH",
  "latitude": 43.813494000000000000000000000,
  "longitude": -71.670031000000000000000000000,
  "categoryId": 0
}
```

### GET /parks/random

_Returns a random park from the database_

- Example Request

```
http://localhost:5000/parks/random
```

- Example Response

```
{
  "parkId": 2,
  "name": "Boston Harbor Islands National Recreation Area",
  "address": "191W Atlantic Ave",
  "city": "Boston",
  "state": "MA",
  "latitude": 42.3601,
  "longitude": -71.052016,
  "categoryId": 3
}
```

---

### Categories

Information on type of parks

---

### GET /categories

_Retrieve a list of all categories in the database_

- Example Request

```
http://localhost:5000/categories
```

- Example Response

```
[
  {
    "categoryId": 1,
    "name": "National Park",
    "description": "Parks mean to preserve, unimpaired, natural and cultural resources for enjoyment, education, and inspiration of this and future generations."
  },
  {
    "categoryId": 2,
    "name": "National Forest",
    "description": "Parks meant to sustain the health, diversity, and productivity of the Nation’s forests and grasslands to meet the needs of many purposes — timber, recreation, grazing, wildlife, fish and more."
  },
  {
    "categoryId": 3,
    "name": "National Recreation Area",
    "description": "Park meant to preserve enhanced recreational opportunities in places with significant natural and scenic resources."
  }
]
```

### POST /categories

_Add category to the database_

- Request Body

```
{
  "name": string
  "description": string
}
```

- Example Request

```
http://localhost:5000/categories
```

- Example Body

```
{
  "name": "National Park",
  "description": "Parks mean to preserve, unimpaired, natural and cultural resources for enjoyment, education, and inspiration of this and future generations."
}
```

- Example Response

```
{
  "categoryId": 1,
  "name": "National Park",
  "description": "Parks mean to preserve, unimpaired, natural and cultural resources for enjoyment, education, and inspiration of this and future generations."
}
```

### GET /categories/{id}

_Retrieve a category by id_

- Example Request

```
http://localhost:5000/categories/2
```

- Example Response

```
{
  "categoryId": 2,
  "name": "National Forest",
  "description": "Parks meant to sustain the health, diversity, and productivity of the Nation’s forests and grasslands to meet the needs of many purposes — timber, recreation, grazing, wildlife, fish and more."
}
```

### PUT /categories/{id}

_Update a category entry_

- Request Body

```
{
  "categoryId": integer
  "name": string
  "description": string
}
```

- Example Request

```
http://localhost:5000/categories/1
```

- Example Body

```
{
  "categoryId": 3,
  "name": "National and State Recreational Area",
  "description": "Park meant to preserve enhanced recreational opportunities in places with significant natural and scenic resources."
}
```

- Example Response

```
{
  "categoryId": 3,
  "name": "National and State Recreational Area",
  "description": "Park meant to preserve enhanced recreational opportunities in places with significant natural and scenic resources."
}
```

### DELETE /categories/{id}

_Delete category entry_

- Example Request

```
http://localhost:5000/categories/1
```

## Known Bugs

- You can add park and category entries with the same information.

## Contact Information

For any questions or comments, please reach out through GitHub.

## License

[MIT License](license)

Copyright (c) 2021 Vanessa Su
