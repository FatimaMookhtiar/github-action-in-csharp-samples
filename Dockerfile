FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
#COPY / App/

COPY ./ App/
WORKDIR App/
RUN pwd
RUN ls 
RUN dotnet restore 
RUN dotnet build --configuration Release
RUN dotnet publish --output /out/ --configuration Release --no-self-contained


FROM mcr.microsoft.com/dotnet/runtime:5.0
COPY --from=build /out .
ENTRYPOINT ["dotnet", "/github-action-in-csharp.dll"]
