# blazor-build-time-configuration

Running the app with default configuration:
```
cd WasmApp
dotnet run
```

Overriding build-time configuration:
```
dotnet build -p:BaseUrl="https://prod.example.com"
dotnet run --no-build
```
