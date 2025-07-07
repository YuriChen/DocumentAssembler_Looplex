# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar arquivos .csproj e restaurar dependências
COPY *.csproj .
RUN dotnet restore

# Copiar todo o código fonte
COPY . .

# Compilar o aplicativo
RUN dotnet publish -c Release -o /app/publish

# Estágio de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar os arquivos publicados
COPY --from=build /app/publish .

# Definir o ponto de entrada
ENTRYPOINT ["dotnet", "documentAssembler.dll"]