FROM mcr.microsoft.com/mssql/server:2019-latest

# Umgebungsvariablen setzen
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=CSharpCool_1!
ENV MSSQL_PID=Express

# Arbeitsverzeichnis im Container festlegen
WORKDIR /usr/src/app

# SQL-Skript in das Container-Verzeichnis kopieren
COPY ./create.sql ./

# Ein Shell-Skript erstellen, das den SQL Server startet und dann das SQL-Skript ausführt
RUN echo "sleep 20s; /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'CSharpCool_1!' -i create.sql" > entrypoint.sh
RUN chmod +x entrypoint.sh

# Das Shell-Skript als Eintrittspunkt setzen, damit es beim Containerstart ausgeführt wird
ENTRYPOINT /bin/bash -c "./entrypoint.sh & /opt/mssql/bin/sqlservr"
