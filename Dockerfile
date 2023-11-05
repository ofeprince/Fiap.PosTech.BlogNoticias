FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /src
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
#COPY *.csproj ./
COPY ["Fiap.PosTech.BlogNoticias.Api/Fiap.PosTech.BlogNoticias.Api.csproj", "Fiap.PosTech.BlogNoticias.Api/"]
#RUN dotnet restore
RUN dotnet restore "Fiap.PosTech.BlogNoticias.Api/Fiap.PosTech.BlogNoticias.Api.csproj"
COPY . .
#WORKDIR /src
WORKDIR "/src/Fiap.PosTech.BlogNoticias.Api"
#RUN dotnet build -c Release -o /app/build
RUN dotnet build "Fiap.PosTech.BlogNoticias.Api.csproj" -c Release -o /app/build

#EXECUTANDO TESTE
WORKDIR "/src/"
COPY ["Fiap.PosTech.BlogNoticias.Testes/Fiap.PosTech.BlogNoticias.Testes.csproj", "Fiap.PosTech.BlogNoticias.Testes/"]
RUN dotnet restore "Fiap.PosTech.BlogNoticias.Testes/Fiap.PosTech.BlogNoticias.Testes.csproj"
COPY . .
WORKDIR "/src/Fiap.PosTech.BlogNoticias.Testes"
RUN dotnet build "Fiap.PosTech.BlogNoticias.Testes.csproj" -c Release -o /app/build
RUN dotnet test "Fiap.PosTech.BlogNoticias.Testes.csproj" --logger "trx;LogFileName=testresults.trx"

FROM build AS publish
WORKDIR "/src/Fiap.PosTech.BlogNoticias.Api"
RUN ls
#RUN dotnet publish -c Release -o /app/publish
RUN dotnet publish "Fiap.PosTech.BlogNoticias.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.PosTech.BlogNoticias.Api.dll"]
