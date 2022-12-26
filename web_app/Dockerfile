
FROM mcr.microsoft.com/dotnet/sdk:6.0 
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet build 
RUN chmod 777 /app/run.sh
ENTRYPOINT [ "/app/run.sh" ]