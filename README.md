# 🌌 Nasa Asteroid Explorer

Nasa Asteroid Explorer is a C#/.NET application that fetches and displays data from NASA's Near-Earth Object Web Service (NeoWs) API - https://api.nasa.gov/. The app retrieves asteroids passing near Earth for a given date range and shows the Astronomy Picture of the Day with support for past periods.

## 🧱 Project Structure

- **WebUI**: Entry point of the application (ASP.NET, Console, etc.)
- **Application**: Core services and DTOs
- **Infrastructure**: HTTP services to fetch data from NASA's API
- **Domain**: Core entities (e.g. NeoAsteroid)
- **Common**: Shared utilities/configuration

## ⚙️ Technologies Used

- .NET 8.0
- C#
- NASA NeoWs API
- Newtonsoft.Json
- HttpClient / Dependency Injection
- Clean Architecture principles

## 🚀 Getting Started

1. **Clone the repository**

```bash
git clone https://github.com/yourusername/NasaAsteroidExplorer.git
cd NasaAsteroidExplorer
```
2. **Configure the API key**

  Create a file appsettings.json in the WebUI project directory:

```bash
{
  "NasaSettings": {
    "NeoUrl": "https://api.nasa.gov/neo/rest/v1/feed",
    "ApodUrl": "https://api.nasa.gov/planetary/apod",
    "ApiKey": "YOUR_API_KEY_HERE"
  }
}
```
3. **Run the application**

Use Visual Studio or run:

```bash
dotnet build
dotnet run --project NasaAsteroidExplorer.WebUI
```
## 📸 Screenshots
![image](https://github.com/user-attachments/assets/abd0453c-cb0f-4e72-b372-02d0fc2ab264)
![image](https://github.com/user-attachments/assets/bd93a470-dbdc-40c9-aa4c-7ccd9427c6f0)
![image](https://github.com/user-attachments/assets/640a7c2e-0151-4baa-bc55-57cfafd71aea)
![image](https://github.com/user-attachments/assets/2baec701-df25-44e2-9231-c8b5838aad4f)


## 📝 License
This project is licensed under the MIT License.

## ✨ Credits
- **NASA NeoWs API**

Replace `yourusername` and tweak anything that might fit the project better.

---
