# chat-signalar-sample

> In this app we use SignalR library for realtime communication between client and server with signalR hub, and it uses web socket under the hood. And in this project application 2 is our server and application 1 is our client. 
> We can have multiple instance for our client (application 1) and all of our instance can comminate with our server.
> SignalR has a scalable mechanism for server and we can scale our server for handling high load traffic.


<a href="https://gitpod.io/#https://github.com/meysamhadeli/chat-signalar-sample"><img alt="Open in Gitpod" src="https://gitpod.io/button/open-in-gitpod.svg"/></a>

# Table of Contents

- [Technologies - Libraries](#technologies---libraries)
- [How to Run](#how-to-run)
  - [Build](#build)
  - [Run](#run)


## Technologies - Libraries

- ✔️ **[`.NET 7`](https://dotnet.microsoft.com/download)** - .NET Framework and .NET Core, including ASP.NET and ASP.NET Core
- ✔️ **[`SignalR`](https://github.com/SignalR/SignalR)** - Real-time web functionality for web apps, including server-side push


## How to Run

> ### Build

To build each project separately use the following command in the root directory: 

#### Application 1 - Desktop App (Client)
```bash
dotnet build Application1/Application1.csproj
```

#### Application 2 - Web App (Server)
```bash
dotnet build Application2/Application2.csproj
```

> ### Run

To run each project separately use the following command in the root directory: 

#### Application 1 - Desktop App (Client)
```bash
dotnet run --project Application1/Application1.csproj
```

#### Application 2 - Web App (Server)
```bash
dotnet run --project Application2/Application2.csproj
```

## License
This project is made available under the MIT license. See [LICENSE](https://github.com/meysamhadeli/chat-signalar-sample/blob/main/LICENSE) for details.
