FROM mcr.microsoft.com/dotnet/core/sdk:2.2
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 5000
EXPOSE 5001
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
