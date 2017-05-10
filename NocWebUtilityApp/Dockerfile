FROM microsoft/aspnetcore:1.1.1
MAINTAINER Daniel Jackson
LABEL Name=NocWebUtilityApp Version=1.0.0
ARG source=.
WORKDIR /app
EXPOSE 80
COPY $source/published .
ENTRYPOINT dotnet NocWebUtilityApp.dll