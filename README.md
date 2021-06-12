# Parks Lookup API

#### API for a MySQL database of parks and park categories.

#### By Vanessa Su

## Description

RESTful API in C# enables access to a MySQL database of parks and park categories. Allows getting all entries for, retrieving particular entries by id, editing entries, and deleting entries for both parks and categories. Parks routes also allow for editing or removing a category association, and selecting a park at random. Park entries have their address geocoded on creation to determine latitude and longitude information in the entry, as well as reformat the state property to a state abbreviation if needed.

## Technologies Used

- C#
- ASP.NET&#8203; Core
- Entity Framework Core
- MySQL
- Swagger
- VS Code

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

- #### Database Setup

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

- #### Run the API Server

1. Navigate to the `/ParksLookupApi` directory
2. Run `dotnet restore`
3. Run `dotnet build`
4. Start the server with `dotnet run`

## API Documentation

### View Swagger Documentation

1. Start the server with `dotnet run`
2. Open http://localhost:5000/index.html in your preferred browser

### Parks

Information on various local, state, and national parks

#### GET /parks

#### POST /parks

#### GET /parks/{id}

#### PUT /parks/{id}

#### DELETE /parks/{id}

#### PUT /parks/{id}/category/{categoryId}

#### DELETE /parks/{id}/category

#### GET /parks/random

### Categories

Information on type of parks

## Known Bugs

- You can add park and category entries with the same information.

## Contact Information

For any questions or comments, please reach out through GitHub.

## License

[MIT License](license)

Copyright (c) 2021 Vanessa Su
